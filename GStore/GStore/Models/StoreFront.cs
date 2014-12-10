﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace GStore.Models
{
	[Table("StoreFronts")]
	public class StoreFront : BaseClasses.ClientRecord
	{
		[Key]
		[Display(Name = "Store Front Id")]
		public int StoreFrontId { get; set; }

		[Required]
		[Index("UniqueRecord", IsUnique = true, Order = 2)]
		[MaxLength(100)]
		public string Name { get; set; }

		[DataType(DataType.Url)]
		[Required]
		[Display(Name = "Public Url")]
		[MaxLength(200)]
		public string PublicUrl { get; set; }

		[Required]
		[MaxLength(50)]
		public string Folder { get; set; }

		public int Order { get; set; }

		[AllowHtml]
		[Display(Name = "Footer Html")]
		[MaxLength(250)]
		public string HtmlFooter { get; set; }

		[AllowHtml]
		[Display(Name = "Body Top Script Tag")]
		public string BodyTopScriptTag { get; set; }

		[AllowHtml]
		[Display(Name = "Body Bottom Script Tag")]
		public string BodyBottomScriptTag { get; set; }

		[Display(Name = "Meta Tag App Name")]
		[MaxLength(250)]
		public string MetaApplicationName { get; set; }

		[Display(Name = "Meta Tag Tile Color")]
		[MaxLength(25)]
		public string MetaApplicationTileColor { get; set; }

		[Display(Name = "Meta Tag Description")]
		[MaxLength(1000)]
		public string MetaDescription { get; set; }

		[Display(Name = "Meta Tag Keywords")]
		[MaxLength(1000)]
		public string MetaKeywords { get; set; }

		[Display(Name = "Show Register link on Login Page")]
		public bool AccountLoginShowRegisterLink { get; set; }

		[Display(Name = "Register link text on Login Page")]
		[MaxLength(50)]
		public string AccountLoginRegisterLinkText { get; set; }

		[Display(Name = "Show Register link on Nav Bar")]
		public bool NavBarShowRegisterLink { get; set; }

		[Display(Name = "Nav Bar Register link text")]
		[MaxLength(50)]
		public string NavBarRegisterLinkText { get; set; }

		[Display(Name = "Catalog Page Initial Levels")]
		[Range(1, 6)]
		public int CatalogPageInitialLevels { get; set; }

		[Display(Name = "Nav Bar Catalog Max Levels")]
		[Range(1, 6)]
		public int NavBarCatalogMaxLevels { get; set; }

		[Display(Name = "Nav Bar Items Max Levels")]
		[Range(1, 6)]
		public int NavBarItemsMaxLevels { get; set; }

		[Required]
		[Display(Name = "Default Layout Name")]
		[MaxLength(10)]
		public string DefaultNewPageLayoutName { get; set; }

		[Display(Name = "Default Theme")]
		[ForeignKey("DefaultNewPageThemeId")]
		public virtual Theme DefaultNewPageTheme { get; set; }

		[Display(Name = "Default Theme Id")]
		public int DefaultNewPageThemeId { get; set; }

		[Required]
		[Display(Name = "Account Layout Name")]
		[MaxLength(10)]
		public string AccountLayoutName { get; set; }

		[Display(Name = "Account Theme")]
		[ForeignKey("AccountThemeId")]
		public virtual Theme AccountTheme { get; set; }

		[Display(Name = "Account Theme Id")]
		public int AccountThemeId { get; set; }

		[Required]
		[Display(Name = "Profile Layout Name")]
		[MaxLength(10)]
		public string ProfileLayoutName { get; set; }

		[Display(Name = "Profile Theme")]
		[ForeignKey("ProfileThemeId")]
		public virtual Theme ProfileTheme { get; set; }

		[Display(Name = "Profile Theme Id")]
		public int ProfileThemeId { get; set; }

		[Required]
		[Display(Name = "Notifications Layout Name")]
		[MaxLength(10)]
		public string NotificationsLayoutName { get; set; }

		[Display(Name = "Notifications Theme")]
		[ForeignKey("NotificationsThemeId")]
		public virtual Theme NotificationsTheme { get; set; }

		[Display(Name = "Notifications Theme Id")]
		public int NotificationsThemeId { get; set; }

		[Required]
		[Display(Name = "Catalog Layout Name")]
		[MaxLength(10)]
		public string CatalogLayoutName { get; set; }

		[Display(Name = "Catalog Theme")]
		[ForeignKey("CatalogThemeId")]
		public virtual Theme CatalogTheme { get; set; }

		[Display(Name = "Catalog Theme Id")]
		public int CatalogThemeId { get; set; }

		[Required]
		[Display(Name = "Store Admin Layout Name")]
		[MaxLength(10)]
		public string AdminLayoutName { get; set; }

		[Display(Name = "Store Admin Theme")]
		[ForeignKey("AdminThemeId")]
		public virtual Theme AdminTheme { get; set; }

		[Display(Name = "Store Admin Theme Id")]
		public int AdminThemeId { get; set; }

		[Required]
		[Display(Name = "Catalog Category col-sm")]
		[Range(1, 12)]
		public int CatalogCategoryColSm { get; set; }

		[Required]
		[Display(Name = "Catalog Category col-md")]
		[Range(1, 12)]
		public int CatalogCategoryColMd { get; set; }

		[Required]
		[Display(Name = "Catalog Category col-lg")]
		[Range(1, 12)]
		public int CatalogCategoryColLg { get; set; }

		[Required]
		[Display(Name = "Catalog Product col-sm")]
		[Range(1, 12)]
		public int CatalogProductColSm { get; set; }

		[Required]
		[Display(Name = "Catalog Product col-md")]
		[Range(1, 12)]
		public int CatalogProductColMd { get; set; }

		[Required]
		[Display(Name = "Catalog Product col-lg")]
		[Range(1, 12)]
		public int CatalogProductColLg { get; set; }

		[Display(Name = "Enable Google Analytics")]
		public bool EnableGoogleAnalytics { get; set; }

		[Display(Name = "Google Analytics Web Property Id")]
		[MaxLength(50)]
		public string GoogleAnalyticsWebPropertyId { get; set; }

		[ForeignKey("WelcomePerson_UserProfileId")]
		[Display(Name = "Welcome Person")]
		public virtual UserProfile WelcomePerson { get; set; }

		[Display(Name = "Welcome Person Id")]
		public int WelcomePerson_UserProfileId { get; set; }

		[ForeignKey("AccountAdmin_UserProfileId")]
		[Display(Name = "Account Admin")]
		public virtual UserProfile AccountAdmin { get; set; }

		[Display(Name = "Account Admin Id")]
		public int AccountAdmin_UserProfileId { get; set; }

		[ForeignKey("RegisteredNotify_UserProfileId")]
		[Display(Name = "Registered Notify")]
		public virtual UserProfile RegisteredNotify { get; set; }

		[Display(Name = "Registered Notify Id")]
		public int RegisteredNotify_UserProfileId { get; set; }

		/// <summary>
		/// File Not Found 404 Store Error Page or null if none (use system default 404 page)
		/// </summary>
		[ForeignKey("Register_WebFormId")]
		[Display(Name = "Register Web Form")]
		public virtual WebForm RegisterWebForm { get; set; }

		[Display(Name = "Register Web Form Id")]
		public int? Register_WebFormId { get; set; }

		/// <summary>
		/// File Not Found 404 Store Error Page or null if none (use system default 404 page)
		/// </summary>
		[ForeignKey("NotFoundError_PageId")]
		[Display(Name = "Not Found Error Page")]
		public virtual Page NotFoundErrorPage { get; set; }

		[Display(Name = "Not Found Error Page Id")]
		public int? NotFoundError_PageId { get; set; }

		/// <summary>
		/// Store Error Page (for any error other than not found 404) or null if none (use system default 404 page)
		/// </summary>
		[ForeignKey("StoreError_PageId")]
		[Display(Name = "Store Error Page")]
		public virtual Page StoreErrorPage { get; set; }

		[Display(Name = "Store Error Page Id")]
		public int? StoreError_PageId { get; set; }

		[Display(Name = "Nav Bar Items")]
		public virtual ICollection<NavBarItem> NavBarItems { get; set; }

		public virtual ICollection<Page> Pages { get; set; }

		public virtual ICollection<Product> Products { get; set; }

		[Display(Name = "Product Categories")]
		public virtual ICollection<ProductCategory> ProductCategories { get; set; }

		[Display(Name = "Store Bindings")]
		public virtual ICollection<StoreBinding> StoreBindings { get; set; }

		[Display(Name = "User Profiles")]
		public virtual ICollection<UserProfile> UserProfiles { get; set; }

		public virtual ICollection<Notification> Notifications { get; set; }


	}
}