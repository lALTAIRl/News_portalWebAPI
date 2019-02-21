namespace News_portal.DAL.Entities
{
    public class NewsApplicationUser
    {
        public int NewsId { get; set; }

        public News FavouriteNews { get; set; }

        public string UserId { get; set; }

        public ApplicationUser UserFavoritedBy { get; set; }
    }
}
