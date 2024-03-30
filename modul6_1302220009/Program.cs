using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

class Program
{
    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public String Username;


        public SayaTubeUser(String username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username), "Username tidak boleh null.");
            if (username.Length > 100)
                throw new ArgumentException("Username tidak boleh lebih dari 100 karakter.", nameof(username));
            this.Username = username;
            var rand = new Random();
            this.id = rand.Next(9999);
            uploadedVideos = new List<SayaTubeVideo>();
        }

        public int GetTotalVideoPlayCount()
        {
            int jmlh = 0;
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                jmlh = jmlh + uploadedVideos[i].getPlayCount();
            }
            return jmlh;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video), "Video tidak boleh null.");
            if (video.getPlayCount() > int.MaxValue)
                throw new ArgumentException("Jumlah playcount video tidak boleh lebih dari batas max integer.", nameof(video));
            uploadedVideos.Add(video);
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine("User: " + Username);
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                if (i > 7)
                {
                    Console.WriteLine("Jumlah Video maksimal yang boleh diprint hanya 8");
                    break;
                }
                Console.WriteLine("Video " + (i + 1) + " judul: " + uploadedVideos[i].getTitle());

            }
        }
    }

    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title), "Judul video tidak boleh null.");
            if (title.Length > 200)
                throw new ArgumentException("Judul video tidak boleh lebih dari 100 karakter.", nameof(title));

            var rand = new Random();
            this.id = rand.Next(9999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int jmlh)
        {
            if (jmlh < 0 || jmlh > 25000000)
                throw new ArgumentOutOfRangeException(nameof(jmlh),
                    "Input penambahan play count harus antara 0 hingga 25,000,000.");

            try
            {
                checked
                {
                    playCount += jmlh;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Play count: " + playCount);
        }

        public int getPlayCount()
        {
            return playCount;
        }

        public String getTitle()
        {
            return title;
        }
    }
    static void Main(String[] args)
    {
        SayaTubeUser user1 = new SayaTubeUser("Marjauza");
        SayaTubeVideo vid1 = new SayaTubeVideo("Review Film Godzilla Minus One oleh Marjauza Naswansyah");
        user1.AddVideo(vid1);
        vid1.IncreasePlayCount(12375);
        SayaTubeVideo vid2 = new SayaTubeVideo("Review Film Kung Fu Panda oleh Marjauza Naswansyah");
        user1.AddVideo(vid2);
        vid2.IncreasePlayCount(50435);
        SayaTubeVideo vid3 = new SayaTubeVideo("Review Film Pengabdi Setan oleh Marjauza Naswansyah");
        user1.AddVideo(vid3);
        vid3.IncreasePlayCount(92804);
        SayaTubeVideo vid4 = new SayaTubeVideo("Review Film Shawshank Redemption oleh Marjauza Naswansyah");
        user1.AddVideo(vid4);
        vid4.IncreasePlayCount(5495);
        SayaTubeVideo vid5 = new SayaTubeVideo("Review Film Truman Show oleh Marjauza Naswansyah");
        user1.AddVideo(vid5);
        vid5.IncreasePlayCount(903285);
        SayaTubeVideo vid6 = new SayaTubeVideo("Review Film Kong oleh Marjauza Naswansyah");
        user1.AddVideo(vid6);
        vid6.IncreasePlayCount(94343);
        SayaTubeVideo vid7 = new SayaTubeVideo("Review Film Jurassic Park oleh Marjauza Naswansyah");
        user1.AddVideo(vid7);
        vid7.IncreasePlayCount(94382);
        SayaTubeVideo vid8 = new SayaTubeVideo("Review Film Back to the Future oleh Marjauza Naswansyah");
        user1.AddVideo(vid8);
        vid8.IncreasePlayCount(423902);
        SayaTubeVideo vid9 = new SayaTubeVideo("Review Film Zootopia oleh Marjauza Naswansyah");
        user1.AddVideo(vid9);
        vid9.IncreasePlayCount(032532);
        SayaTubeVideo vid10 = new SayaTubeVideo("Review Film Aquaman oleh Marjauza Naswansyah");
        user1.AddVideo(vid10);
        vid10.IncreasePlayCount(51873);

        vid4.PrintVideoDetails();
        Console.WriteLine();

        Console.WriteLine(user1.Username + " memiliki total playcount: " + user1.GetTotalVideoPlayCount());
        Console.WriteLine();

        try
        {
            user1.PrintAllVideoPlaycount();
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        try
        {
            SayaTubeUser user2 = new SayaTubeUser(null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            SayaTubeUser user3 = new SayaTubeUser("mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            SayaTubeVideo vid11 = new SayaTubeVideo(null);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        try
        {
            SayaTubeVideo vid12 = new SayaTubeVideo("mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        try
        {
            SayaTubeVideo vid13 = new SayaTubeVideo("Tutorial Design By Contract – Marjauza Naswansyah");
            vid4.IncreasePlayCount(100000000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        SayaTubeVideo vid14 = new SayaTubeVideo("Tutorial Design By Contract – Marjauza Naswansyah");

        for (int i = 0; i < 100; i++)
        {
            vid14.IncreasePlayCount(25000000);
        }

        vid14.PrintVideoDetails();
    }
}