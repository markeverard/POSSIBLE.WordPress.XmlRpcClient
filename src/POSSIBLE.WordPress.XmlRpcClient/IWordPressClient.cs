using POSSIBLE.WordPress.XmlRpcClient.Models;

namespace POSSIBLE.WordPress.XmlRpcClient
{
    public interface IWordPressClient
    {
        UploadItem UploadFile(string filenameIncludingExtension, string pathToFileToUpload, string type = "image/jpeg");
    }
}