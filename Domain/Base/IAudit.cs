namespace Domain
{
    using System;

    public interface IAudit
    {
        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        string ModifiedBy { get; set; }

    }
}