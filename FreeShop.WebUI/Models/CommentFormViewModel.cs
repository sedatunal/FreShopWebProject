namespace FreeShop.WebUI.Models
{
    public class CommentFormViewModel
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int Rate { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
    }
}
