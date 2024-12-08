using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Utility
{
    public static class SD
    {

        public const string Role_Customer = "Customer";
        public const string Role_Company = "Company";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
		public const string Role_Moderator = "Moderator";
        public const string Role_Captain = "Captain";
        public const string Role_Sergeant = "Sergeant";

        public const string StatusPending = "Pending";
		public const string StatusApproved = "Approved";
		public const string StatusInProcess = "Processing";
		public const string StatusShipped = "Shipped";
		public const string StatusCancelled = "Cancelled";
		public const string StatusRefunded = "Refunded";

		public const string NewOrder = "NewOrder";
		public const string P21Entered = "P21Entered";
		public const string ShippedInvoiced = "ShippedInvoiced";
		public const string Paid = "Paid";
		public const int StatusIdNew = 1;
        public const int StatusIdP21 = 2;
        public const int StatusIdShipped = 3;
        public const int StatusIdPaid = 4;

        public const string PaymentStatusPending = "Pending";
		public const string PaymentStatusApproved = "Approved";
		public const string PaymentStatusDelayedPayment = "ApprovedFor DelayedPayment";
		public const string PaymentStatusRejected = "Rejected";

		public const string SessionCart = "SessionShoppingCart";

		public const string Tractor = "Tractor";
		public const string Trailer = "Trailer";
        public const string Misc = "Misc";

    }
}
