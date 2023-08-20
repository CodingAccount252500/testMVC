namespace testMVC.DTO.Req
{
	public class CourseRegstration
	{
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
        public DateTime ReqDate { get; set; }
    }
}
