namespace FabricStore.Data.Extensions
{
    using System.Drawing;
    using System.IO;
    using System.Net;

    public static class Extensions
    {
        /// <summary>
        /// This method is used to download a image from given url and put this image inside the seed data
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Image GetImageFromUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
        }
    }
}
