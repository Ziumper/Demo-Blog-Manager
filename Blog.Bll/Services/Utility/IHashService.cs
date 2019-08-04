namespace Blog.Bll.Services.Utility {


    public interface IHashService
    {
        string GetHash(string input);

        string GetRandomActivationCode();
    } 

    
}