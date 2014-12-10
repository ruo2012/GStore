﻿using GStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GStore.AppHtmlHelpers;

namespace GStore.Data
{
	/// <summary>
	/// Applies sort for a controller including sort descending/ascending from ActionSortLink displays
	/// Converts IQueryable to IOrderedQueryable
	/// </summary>
	public static class SortExtensions
	{
		public static IOrderedQueryable<Client> ApplySort(this IQueryable<Client> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<Client> orderedQuery = null;

			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Name);
					}
					break;

				case "folder":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Folder);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Folder);
					}
					break;

				case "enablepageviewlog":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EnablePageViewLog);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EnablePageViewLog);
					}
					break;

				case "enablenewuserregisteredbroadcast":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EnableNewUserRegisteredBroadcast);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EnableNewUserRegisteredBroadcast);
					}
					break;

				case "status" :
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "usesendgridemail":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UseSendGridEmail);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UseSendGridEmail);
					}
					break;

				case "usetwiliosms":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UseTwilioSms);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UseTwilioSms);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Order).ThenBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Order).ThenByDescending(c => c.ClientId);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				return orderedQuery.ThenBy(c => c.Order).ThenBy(c => c.ClientId);
			}
			else if (!defaultSort && !sortAscending)
			{
				return orderedQuery.ThenByDescending(c => c.Order).ThenByDescending(c => c.ClientId);
			}
			return orderedQuery;
		}

		public static IOrderedQueryable<StoreFront> ApplySort(this IQueryable<StoreFront> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<StoreFront> orderedQuery = null;

			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "client":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.Name);
					}
					break;

				case "clientstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "client.ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.IsPending);
					}
					break;

				case "client.startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.StartDateTimeUtc);
					}
					break;

				case "client.enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.EndDateTimeUtc);
					}
					break;

				case "storefrontid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StoreFrontId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StoreFrontId);
					}
					break;

				case "status":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "publicurl":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.PublicUrl);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.PublicUrl);
					}
					break;

				case "name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Name);
					}
					break;

				case "folder":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Folder);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Folder);
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(sf => sf.Client.Order).ThenBy(sf => sf.Client.ClientId).ThenBy(sf => sf.Order).ThenBy(sf => sf.StoreFrontId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(sf => sf.Client.Order).ThenByDescending(sf => sf.Client.ClientId).ThenByDescending(sf => sf.Order).ThenByDescending(sf => sf.StoreFrontId);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				return orderedQuery.ThenBy(sf => sf.Client.Order).ThenBy(sf => sf.Client.ClientId).ThenBy(sf => sf.Order).ThenBy(sf => sf.StoreFrontId);
			}
			else if (!defaultSort && !sortAscending)
			{
				return orderedQuery.ThenByDescending(sf => sf.Client.Order).ThenByDescending(sf => sf.Client.ClientId).ThenByDescending(sf => sf.Order).ThenByDescending(sf => sf.StoreFrontId);
			}
			return orderedQuery;

		}

		public static IOrderedQueryable<StoreBinding> ApplySort(this IQueryable<StoreBinding> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<StoreBinding> orderedQuery = null;

			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "client":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.Name);
					}
					break;

				case "clientstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "storefrontid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StoreFront.StoreFrontId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StoreFront.StoreFrontId);
					}
					break;

				case "storefront":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StoreFront.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StoreFront.Name);
					}
					break;


				case "storefrontstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.StoreFront.IsPending || c.StoreFront.StartDateTimeUtc > DateTime.UtcNow || c.StoreFront.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.StoreFront.IsPending || c.StoreFront.StartDateTimeUtc > DateTime.UtcNow || c.StoreFront.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "hostname":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.HostName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.HostName);
					}
					break;

				case "port":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Port);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Port);
					}
					break;

				case "rootpath":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.RootPath);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.RootPath);
					}
					break;

				case "useurlstorename":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UseUrlStoreName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UseUrlStoreName);
					}
					break;

				case "urlstorename":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UrlStoreName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UrlStoreName);
					}
					break;

				case "order":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Order);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Order);
					}
					break;

				case "status":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(sb => sb.Client.Order)
							.ThenBy(sb => sb.Client.ClientId)
							.ThenBy(sb => sb.StoreFront.Order)
							.ThenBy(sb => sb.StoreFrontId)
							.ThenBy(sb => sb.Order)
							.ThenBy(sb => sb.StoreBindingId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(sb => sb.Client.Order)
							.ThenByDescending(sb => sb.Client.ClientId)
							.ThenByDescending(sb => sb.StoreFront.Order)
							.ThenByDescending(sb => sb.StoreFrontId)
							.ThenByDescending(sb => sb.Order)
							.ThenByDescending(sb => sb.StoreBindingId);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				return orderedQuery.ThenBy(sb => sb.Client.Order)
							.ThenBy(sb => sb.Client.ClientId)
							.ThenBy(sb => sb.StoreFront.Order)
							.ThenBy(sb => sb.StoreFrontId)
							.ThenBy(sb => sb.Order)
							.ThenBy(sb => sb.StoreBindingId);
			}
			else if (!defaultSort && !sortAscending)
			{
				return orderedQuery.ThenByDescending(sb => sb.Client.Order)
					.ThenByDescending(sb => sb.Client.ClientId)
					.ThenByDescending(sb => sb.StoreFront.Order)
					.ThenByDescending(sb => sb.StoreFrontId)
					.ThenByDescending(sb => sb.Order)
					.ThenByDescending(sb => sb.StoreBindingId);
			}
			return orderedQuery;
		}

		public static IOrderedQueryable<UserProfile> ApplySort(this IQueryable<UserProfile> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<UserProfile> orderedQuery = null;
			
			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "client":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.Name);
					}
					break;

				case "clientstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "storefrontid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StoreFront.StoreFrontId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StoreFront.StoreFrontId);
					}
					break;

				case "storefront":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StoreFront.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StoreFront.Name);
					}
					break;


				case "storefrontstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.StoreFront.IsPending || c.StoreFront.StartDateTimeUtc > DateTime.UtcNow || c.StoreFront.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.StoreFront.IsPending || c.StoreFront.StartDateTimeUtc > DateTime.UtcNow || c.StoreFront.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "storefront.name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StoreFront.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StoreFront.Name);
					}
					break;

				case "userprofileid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UserProfileId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UserProfileId);
					}
					break;

				case "username":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UserName);
					}
					break;

				case "email":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Email);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Email);
					}
					break;

				case "fullname":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.FullName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.FullName);
					}
					break;

				case "lastlogondatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.LastLogonDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.LastLogonDateTimeUtc);
					}
					break;

				case "order":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Order);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Order);
					}
					break;

				case "status":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => p.Client.Order)
							.ThenBy(p => p.ClientId)
							.ThenBy(p => p.StoreFront.Order)
							.ThenBy(p => p.StoreFrontId)
							.ThenBy(p => p.Order)
							.ThenBy(p => p.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => p.Client.Order)
							.ThenByDescending(p => p.ClientId)
							.ThenByDescending(p => p.StoreFront.Order)
							.ThenByDescending(p => p.StoreFrontId)
							.ThenByDescending(p => p.Order)
							.ThenByDescending(p => p.UserName);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				return orderedQuery.ThenBy(p => p.Client.Order)
					.ThenBy(p => p.ClientId)
					.ThenBy(p => p.StoreFront.Order)
					.ThenBy(p => p.StoreFrontId)
					.ThenBy(p => p.Order)
					.ThenBy(p => p.UserName);
			}
			else if (!defaultSort && !sortAscending)
			{
				return orderedQuery.ThenByDescending(p => p.Client.Order)
					.ThenByDescending(p => p.ClientId)
					.ThenByDescending(p => p.StoreFront.Order)
					.ThenByDescending(p => p.StoreFrontId)
					.ThenByDescending(p => p.Order)
					.ThenByDescending(p => p.UserName);
			}
			return orderedQuery;
		}

		public static IOrderedQueryable<ValueList> ApplySort(this IQueryable<ValueList> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<ValueList> orderedQuery = null;

			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "client":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.Name);
					}
					break;

				case "name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Name);
					}
					break;

				case "allowedit":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.AllowEdit);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.AllowEdit);
					}
					break;

				case "allowdelete":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.AllowDelete);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.AllowDelete);
					}
					break;

				case "ismultiselect":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsMultiSelect);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsMultiSelect);
					}
					break;

				case "clientstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "valuelistid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(vl => vl.ValueListId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(vl => vl.ValueListId);
					}
					break;


				case "order":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Order);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Order);
					}
					break;

				case "status":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => p.Client.Order)
							.ThenBy(p => p.ClientId)
							.ThenBy(p => p.Order)
							.ThenBy(p => p.ValueListId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => p.Client.Order)
							.ThenByDescending(p => p.ClientId)
							.ThenByDescending(p => p.Order)
							.ThenByDescending(p => p.ValueListId);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				return orderedQuery.ThenBy(p => p.Client.Order)
					.ThenBy(p => p.ClientId)
					.ThenBy(p => p.Order)
					.ThenBy(p => p.ValueListId);
			}
			else if (!defaultSort && !sortAscending)
			{
				return orderedQuery.ThenByDescending(p => p.Client.Order)
					.ThenByDescending(p => p.ClientId)
					.ThenByDescending(p => p.Order)
					.ThenByDescending(p => p.ValueListId);
			}
			return orderedQuery;
		}

		public static IOrderedQueryable<WebForm> ApplySort(this IQueryable<WebForm> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<WebForm> orderedQuery = null;

			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "client":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.Name);
					}
					break;

				case "clientstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Name);
					}
					break;

				case "webformid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(vl => vl.WebFormId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(vl => vl.WebFormId);
					}
					break;


				case "order":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Order);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Order);
					}
					break;

				case "status":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => p.Client.Order)
							.ThenBy(p => p.ClientId)
							.ThenBy(p => p.Order)
							.ThenBy(p => p.WebFormId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => p.Client.Order)
							.ThenByDescending(p => p.ClientId)
							.ThenByDescending(p => p.Order)
							.ThenByDescending(p => p.WebFormId);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				return orderedQuery.ThenBy(p => p.Client.Order)
					.ThenBy(p => p.ClientId)
					.ThenBy(p => p.Order)
					.ThenBy(p => p.WebFormId);
			}
			else if (!defaultSort && !sortAscending)
			{
				return orderedQuery.ThenByDescending(p => p.Client.Order)
					.ThenByDescending(p => p.ClientId)
					.ThenByDescending(p => p.Order)
					.ThenByDescending(p => p.WebFormId);
			}
			return orderedQuery;
		}

		public static IOrderedQueryable<WebFormField>ApplySortDefault(this IQueryable<WebFormField> query)
		{
			return query.ApplySort(null, null, null);
		}

		public static IOrderedQueryable<WebFormField> ApplySort(this IQueryable<WebFormField> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<WebFormField> orderedQuery = null;

			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "client":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.Name);
					}
					break;

				case "clientstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Name);
					}
					break;

				case "webformid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(vl => vl.WebFormId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(vl => vl.WebFormId);
					}
					break;

				case "webformfieldid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(vl => vl.WebFormFieldId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(vl => vl.WebFormFieldId);
					}
					break;


				case "order":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Order);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Order);
					}
					break;

				case "status":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => p.Client.Order)
							.ThenBy(p => p.ClientId)
							.ThenBy(p => p.WebForm.Order)
							.ThenBy(p => p.WebFormId)
							.ThenBy(p => p.Order)
							.ThenBy(p => p.WebFormFieldId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => p.Client.Order)
							.ThenByDescending(p => p.ClientId)
							.ThenByDescending(p => p.WebForm.Order)
							.ThenByDescending(p => p.WebFormId)
							.ThenByDescending(p => p.Order)
							.ThenByDescending(p => p.WebFormFieldId);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				return orderedQuery.ThenBy(p => p.Client.Order)
					.ThenBy(p => p.ClientId)
					.ThenBy(p => p.WebForm.Order)
					.ThenBy(p => p.WebFormId)
					.ThenBy(p => p.Order)
					.ThenBy(p => p.WebFormFieldId);
			}
			else if (!defaultSort && !sortAscending)
			{
				return orderedQuery.ThenByDescending(p => p.Client.Order)
					.ThenByDescending(p => p.ClientId)
					.ThenByDescending(p => p.WebForm.Order)
					.ThenByDescending(p => p.WebFormId)
					.ThenByDescending(p => p.Order)
					.ThenByDescending(p => p.WebFormFieldId);
			}
			return orderedQuery;
		}


		public static IOrderedQueryable<Page> ApplyDefaultSort(this IQueryable<Page> query)
		{
			return query.ApplySort(null, null, null);
		}

		public static IOrderedQueryable<Page> ApplySort(this IQueryable<Page> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<Page> orderedQuery = null;

			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "client":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.Name);
					}
					break;

				case "clientstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "pagetemplate.name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => p.PageTemplate.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => p.PageTemplate.Name);
					}
					break;

				case "theme.name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => p.Theme.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => p.Theme.Name);
					}
					break;

				case "webform.name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => (p.WebForm == null ? string.Empty : p.WebForm.Name));
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => (p.WebForm == null ? string.Empty : p.WebForm.Name));
					}
					break;

				case "name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Name);
					}
					break;

				case "pageid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(vl => vl.PageId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(vl => vl.PageId);
					}
					break;

				case "pagetitle":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(vl => vl.PageTitle);
					}
					else
					{
						orderedQuery = query.OrderByDescending(vl => vl.PageTitle);
					}
					break;

				case "url":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(vl => vl.Url);
					}
					else
					{
						orderedQuery = query.OrderByDescending(vl => vl.Url);
					}
					break;

				case "order":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Order);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Order);
					}
					break;

				case "status":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => p.Client.Order)
							.ThenBy(p => p.ClientId)
							.ThenBy(p=> p.StoreFront.Order)
							.ThenBy(p=> p.StoreFront.StoreFrontId)
							.ThenBy(p => p.Order)
							.ThenBy(p => p.PageId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => p.Client.Order)
							.ThenByDescending(p => p.ClientId)
							.ThenByDescending(p => p.StoreFront.Order)
							.ThenByDescending(p => p.StoreFront.StoreFrontId)
							.ThenByDescending(p => p.Order)
							.ThenByDescending(p => p.PageId);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				orderedQuery = orderedQuery.ThenBy(p => p.Client.Order)
					.ThenBy(p => p.ClientId)
					.ThenBy(p => p.StoreFront.Order)
					.ThenBy(p => p.StoreFront.StoreFrontId)
					.ThenBy(p => p.Order)
					.ThenBy(p => p.PageId);
			}
			else if (!defaultSort && !sortAscending)
			{
				orderedQuery = orderedQuery.ThenByDescending(p => p.Client.Order)
					.ThenByDescending(p => p.ClientId)
					.ThenByDescending(p => p.StoreFront.Order)
					.ThenByDescending(p => p.StoreFront.StoreFrontId)
					.ThenByDescending(p => p.Order)
					.ThenByDescending(p => p.PageId);
			}
			return orderedQuery;
		}

		public static IOrderedQueryable<PageTemplate> ApplySort(this IQueryable<PageTemplate> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<PageTemplate> orderedQuery = null;

			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "client":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.Name);
					}
					break;

				case "clientstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;


				case "name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Name);
					}
					break;

				case "pagetemplateid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.PageTemplateId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.PageTemplateId);
					}
					break;

				case "layoutname":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.LayoutName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.LayoutName);
					}
					break;

				case "viewname":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ViewName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ViewName);
					}
					break;

				case "order":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Order);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Order);
					}
					break;

				case "sections":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Sections.Count);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Sections.Count);
					}
					break;

				case "status":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => p.Client.Order)
							.ThenBy(p => p.ClientId)
							.ThenBy(p => p.Order)
							.ThenBy(p => p.PageTemplateId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => p.Client.Order)
							.ThenByDescending(p => p.ClientId)
							.ThenByDescending(p => p.Order)
							.ThenByDescending(p => p.PageTemplateId);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				orderedQuery = orderedQuery.ThenBy(p => p.Client.Order)
					.ThenBy(p => p.ClientId)
					.ThenBy(p => p.Order)
					.ThenBy(p => p.PageTemplateId);
			}
			else if (!defaultSort && !sortAscending)
			{
				orderedQuery = orderedQuery.OrderByDescending(p => p.Client.Order)
					.ThenByDescending(p => p.ClientId)
					.ThenByDescending(p => p.Order)
					.ThenByDescending(p => p.PageTemplateId);
			}
			return orderedQuery;
		}


		public static IOrderedQueryable<Theme> ApplySort(this IQueryable<Theme> query, Controllers.BaseClass.BaseController controller, string SortBy, bool? SortAscending)
		{
			string sortBy = (string.IsNullOrEmpty(SortBy) ? string.Empty : SortBy.Trim().ToLower());
			bool sortAscending = (SortAscending.HasValue ? SortAscending.Value : true);
			IOrderedQueryable<Theme> orderedQuery = null;

			bool defaultSort = false;
			switch (sortBy ?? string.Empty)
			{
				case "clientid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ClientId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ClientId);
					}
					break;

				case "client":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Client.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Client.Name);
					}
					break;

				case "clientstatus":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.Client.IsPending || c.Client.StartDateTimeUtc > DateTime.UtcNow || c.Client.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;


				case "themeid":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.ThemeId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.ThemeId);
					}
					break;

				case "name":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Name);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Name);
					}
					break;

				case "foldername":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.FolderName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.FolderName);
					}
					break;

				case "order":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.Order);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.Order);
					}
					break;

				case "status":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => (c.IsPending || c.StartDateTimeUtc > DateTime.UtcNow || c.EndDateTimeUtc < DateTime.UtcNow));
					}
					break;

				case "ispending":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.IsPending);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.IsPending);
					}
					break;

				case "startdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.StartDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.StartDateTimeUtc);
					}
					break;

				case "enddatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.EndDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.EndDateTimeUtc);
					}
					break;

				case "createdatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreateDateTimeUtc);
					}
					break;

				case "createdby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.CreatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.CreatedBy.UserName);
					}
					break;

				case "updatedatetimeutc":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdateDateTimeUtc);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdateDateTimeUtc);
					}
					break;

				case "updatedby":
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(c => c.UpdatedBy.UserName);
					}
					else
					{
						orderedQuery = query.OrderByDescending(c => c.UpdatedBy.UserName);
					}
					break;

				case "":
					//default sort
					defaultSort = true;
					if (sortAscending)
					{
						orderedQuery = query.OrderBy(p => p.Client.Order)
							.ThenBy(p => p.ClientId)
							.ThenBy(p => p.Order)
							.ThenBy(p => p.ThemeId);
					}
					else
					{
						orderedQuery = query.OrderByDescending(p => p.Client.Order)
							.ThenByDescending(p => p.ClientId)
							.ThenByDescending(p => p.Order)
							.ThenByDescending(p => p.ThemeId);
					}
					break;


				default:
					//unknown sort
					if (controller != null)
					{
						System.Diagnostics.Trace.WriteLine("Unknown sort: " + SortBy);
						controller.AddUserMessage("Unknown sort", "Unknown sort: " + SortBy.ToHtml(), AppHtmlHelpers.UserMessageType.Info);
					}
					goto case "";
			}

			if (!defaultSort && sortAscending)
			{
				orderedQuery = orderedQuery.ThenBy(p => p.Client.Order)
					.ThenBy(p => p.ClientId)
					.ThenBy(p => p.Order)
					.ThenBy(p => p.ThemeId);
			}
			else if (!defaultSort && !sortAscending)
			{
				orderedQuery = orderedQuery.OrderByDescending(p => p.Client.Order)
					.ThenByDescending(p => p.ClientId)
					.ThenByDescending(p => p.Order)
					.ThenByDescending(p => p.ThemeId);
			}
			return orderedQuery;
		}


	}
}