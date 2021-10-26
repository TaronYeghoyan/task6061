namespace Domain.POCO.DTOs
{
    public class CalculateReportEmployeeDto
    {
        /// <summary>
        /// First Name + Last Name
        /// </summary>
        public string fnln { get; set; }

        /// <summary>
        /// Department Name
        /// </summary>
        public string dn { get; set; }

        /// <summary>
        /// Employee's wage
        /// </summary>
        public int w { get; set; }

        /// <summary>
        /// Employee’s workdays
        /// </summary>
        public int wd { get; set; }

        /// <summary>
        /// Earned salary during the period (start to end time)
        /// </summary>
        public uint st { get; set; }

        /// <summary>
        /// Working days during the period (start to end time)
        /// </summary>
        public uint wdt { get; set; }
    }
}