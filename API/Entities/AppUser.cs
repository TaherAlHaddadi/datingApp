namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }// Column 
        public string UserName { get; set; }// Column 

        public byte[] PasswordHash{get;set;}

        public byte[] PasswordSalt{get;set;}

    }
}