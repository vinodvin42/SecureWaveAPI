using System;
using System.Collections.Generic;

namespace SecureWave.Models
{
    public class ApprovalWorkflow
    {
        // Primary Key
        public Guid WorkflowId { get; set; } = Guid.NewGuid();

        // Workflow Details
        public string WorkflowName { get; set; } // Name of the workflow
        public int ApprovalLevels { get; set; } // Number of approval levels

        // Navigation Properties
        public ICollection<AccessRequest> AccessRequests { get; set; } = new List<AccessRequest>(); // One-to-Many with AccessRequests
    }
}