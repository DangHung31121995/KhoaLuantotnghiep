using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure.Enums;

namespace Ecommerce.Service.ViewModels
{
    public class AuditViewModel : ViewModelBase<Audit, AuditViewModel>
    {
        #region Public Properties
        public string Id { get; set; }
        public string Content { get; set; }
        public string Level { get; set; } = AuditLevel.Info.ToString();
        public DateTime? CreatedOn { get; set; }
        //public string CreatedOnValue => CreatedOn != null ? CreatedOn.ConvertToString("dd/MM/yyyy") : string.Empty;
       // public string CreatedUsDate => CreatedDate == null ? string.Empty : CreatedDate.ConvertToString("MM/dd/yyyy hh:mm");
        public DateTime? ChangeOn { get; set; }
        public string ChangeBy { get; set; }
        public string CreatedBy { get; set; }
        #endregion Public Properties
    }
}
