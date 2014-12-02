﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GStore.Data.EntityFrameworkCodeFirstProvider;
using GStore.Models;
using GStore.Data;

namespace GStore.Areas.SystemAdmin.Controllers
{
	public class UserProfileSysAdminController : BaseClasses.SystemAdminBaseController
	{

		public ActionResult Index(int? clientId, int? storeFrontId, string SortBy, bool? SortAscending)
		{
			ViewBag.ClientFilterList = ClientFilterList(clientId);
			ViewBag.StoreFrontFilterList = StoreFrontFilterList(clientId, storeFrontId);

			IQueryable<UserProfile> query = null;
			if (!clientId.HasValue)
			{
				//no client filter (none)
				query = GStoreDb.UserProfiles.Where(p => p.ClientId == null);
			}
			else if (clientId.Value == 0)
			{
				//no client filter (all)
				query = GStoreDb.UserProfiles.All();
			}
			else
			{
				query = GStoreDb.UserProfiles.Where(p => p.ClientId == clientId.Value);
			}

			if (!clientId.HasValue)
			{
				//no client or storefront filter; show nulls (none)
				query = GStoreDb.UserProfiles.Where(p => p.StoreFrontId == null);
			}
			else if (!storeFrontId.HasValue)
			{
				//client filtered, but nothing on storefront, show all
			}
			else if (storeFrontId.Value == 0)
			{
				//no filter (all)
			}
			else
			{
				query = GStoreDb.UserProfiles.Where(p => p.StoreFrontId == storeFrontId.Value);
			}

			IOrderedQueryable<UserProfile> queryOrdered = query.ApplySort(this, SortBy, SortAscending);
			return View(queryOrdered.ToList());
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return HttpBadRequest("User Profile id is null");
			}
			UserProfile profile = GStoreDb.UserProfiles.FindById(id.Value);
			if (profile == null)
			{
				return HttpNotFound();
			}

			return View(profile);
		}

		public ActionResult Create(int? clientId, int? storeFrontId)
		{
			ViewBag.UserProfileList = UserProfileList(clientId, storeFrontId);
			ViewBag.ClientList = ClientList();
			ViewBag.StoreFrontList = StoreFrontList(clientId);
			ViewData.Add("CreateLoginAndIdentity", true);
			ViewData.Add("Password", string.Empty);
			ViewData.Add("SendWelcomeMessage", true);
			ViewData.Add("SendRegisteredNotify", true);

			UserProfile model = GStoreDb.UserProfiles.Create();
			model.SetDefaultsForNew(clientId, storeFrontId);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(UserProfile profile, string Password, bool? CreateLoginAndIdentity, bool? SendUserWelcome, bool? SendRegisteredNotify)
		{
			ViewData.Add("CreateLoginAndIdentity", CreateLoginAndIdentity);
			ViewData.Add("Password", Password);
			ViewData.Add("SendWelcomeMessage", SendUserWelcome);
			ViewData.Add("SendRegisteredNotify", SendRegisteredNotify);

			Identity.AspNetIdentityUser identityUser = null;

			if (ModelState.IsValid)
			{
				Identity.AspNetIdentityContext identityCtx = new Identity.AspNetIdentityContext();
				
				if (CreateLoginAndIdentity.HasValue && CreateLoginAndIdentity.Value)
				{
					if (identityCtx.Users.Any(u => u.UserName == profile.UserName))
					{
						ModelState.AddModelError("UserName", "User Name is already taken, choose a new user name or edit the original user.");
					}
					if (identityCtx.Users.Any(u => u.Id == profile.UserId))
					{
						ModelState.AddModelError("UserId", "User Id is already taken, choose a new UserId or edit the original user.");
					}
					if (identityCtx.Users.Any(u => u.Email == profile.Email))
					{
						ModelState.AddModelError("Email", "Email is already taken, choose a new UserId or edit the original user.");
					}

					if (string.IsNullOrEmpty(Password))
					{
						ModelState.AddModelError("Password", "Password is null, enter a password for this user or uncheck Create Login And Identity.");
					}
					else if (Password.Length < 6)
					{
						ModelState.AddModelError("Password", "Password is too short. You must have at least 6 characters.");
					}

					if (ModelState.IsValid)
					{
						identityUser = identityCtx.CreateUserIfNotExists(profile.UserName, profile.Email, null, Password);
					}
				}

				
			}

			if (ModelState.IsValid)
			{
				UserProfile newProfile = GStoreDb.UserProfiles.Create(profile);
				newProfile.UpdateAuditFields(CurrentUserProfileOrThrow);
				if (identityUser != null)
				{
					newProfile.UserId = identityUser.Id;
				}
				else
				{
					newProfile.UserId = profile.Email;
				}
				newProfile = GStoreDb.UserProfiles.Add(newProfile);
				GStoreDb.SaveChanges();

				GStoreDb.LogSecurityEvent_NewRegister(this.HttpContext, RouteData, newProfile, this);
				if ((SendUserWelcome ?? true) || (SendRegisteredNotify ?? true))
				{
					string notificationBaseUrl = Url.Action("Details", "Notifications", new { id = "" });
					CurrentStoreFrontOrThrow.HandleNewUserRegisteredNotifications(this.GStoreDb, Request, newProfile, notificationBaseUrl, SendUserWelcome ?? true, SendRegisteredNotify ?? true);
				}

				return RedirectToAction("Index");
			}

			int? clientId = null;
			if (profile.ClientId != default(int))
			{
				clientId = profile.ClientId;
			}
			int? storeFrontId = null;
			if (profile.StoreFrontId != default(int))
			{
				storeFrontId = profile.StoreFrontId;
			}

			ViewBag.UserProfileList = UserProfileList(clientId, storeFrontId);
			ViewBag.ClientList = ClientList();
			ViewBag.StoreFrontList = StoreFrontList(clientId);

			return View(profile);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return HttpBadRequest("User Profile id is null");
			}
			UserProfile profile = GStoreDb.UserProfiles.FindById(id.Value);
			if (profile == null)
			{
				return HttpNotFound();
			}

			ViewBag.UserProfileList = UserProfileList(profile.ClientId, profile.StoreFrontId);
			ViewBag.ClientList = ClientList();
			ViewBag.StoreFrontList = StoreFrontList(profile.ClientId);

			return View(profile);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(UserProfile profile)
		{
			if (ModelState.IsValid)
			{
				profile.UpdateAuditFields(CurrentUserProfileOrThrow);
				profile = GStoreDb.UserProfiles.Update(profile);
				GStoreDb.SaveChanges();

				return RedirectToAction("Index");
			}
			ViewBag.UserProfileList = UserProfileList(profile.ClientId, profile.StoreFrontId);
			ViewBag.ClientList = ClientList();
			ViewBag.StoreFrontList = StoreFrontList(profile.ClientId);

			return View(profile);
		}

		public ActionResult Activate(int id)
		{
			this.ActivateUserProfile(id);
			if (Request.UrlReferrer != null)
			{
				return Redirect(Request.UrlReferrer.ToString());
			}
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return HttpBadRequest("User Profile id is null");
			}
			Data.IGstoreDb db = GStoreDb;
			UserProfile profile = db.UserProfiles.FindById(id.Value);
			if (profile == null)
			{
				return HttpNotFound();
			}
			return View(profile);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{
				UserProfile target = GStoreDb.UserProfiles.FindById(id);
				if (target == null)
				{
					//user profile not found, already deleted? overpost?
					throw new ApplicationException("Error deleting User Profile. User Profile not found. It may have been deleted by another user. User Profile Id: " + id);
				}

				bool deleted = GStoreDb.UserProfiles.DeleteById(id);
				GStoreDb.SaveChanges();
				AddUserMessage("User Profile deleted", "User Profile Id [" + id + "] was deleted successfully.", AppHtmlHelpers.UserMessageType.Info);
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error deleting User Profile.  See inner exception for errors.  Related child tables may still have data to be deleted. User Profile Id: " + id, ex);
			}
			return RedirectToAction("Index");
		}

	}
}