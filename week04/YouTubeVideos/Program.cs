using System;

class Program
{
    static void Main(string[] args)

    {Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learn C# in 20 Minutes", "Programming Hub", 1200);

        video1.AddComment(new Comment("David", "Very easy to understand!"));
        video1.AddComment(new Comment("Sarah", "This helped me a lot."));
        video1.AddComment(new Comment("John", "Excellent explanation."));
        video1.AddComment(new Comment("Grace", "Thanks for sharing."));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Object-Oriented Programming", "Code Academy", 950);

        video2.AddComment(new Comment("Michael", "Great lesson."));
        video2.AddComment(new Comment("Linda", "I finally understand classes."));
        video2.AddComment(new Comment("Peter", "Very informative."));
        video2.AddComment(new Comment("James", "Awesome video!"));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Lists in C#", "Tech World", 780);

        video3.AddComment(new Comment("Mary", "Simple explanation."));
        video3.AddComment(new Comment("Samuel", "Exactly what I needed."));
        video3.AddComment(new Comment("Sophia", "Thank you!"));
        video3.AddComment(new Comment("Daniel", "Excellent tutorial."));

        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Methods and Functions", "Coding School", 680);

        video4.AddComment(new Comment("Joseph", "Very helpful."));
        video4.AddComment(new Comment("David", "Nice examples."));
        video4.AddComment(new Comment("Henry", "I learned a lot."));
        video4.AddComment(new Comment("Emma", "Great content."));

        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("\nComments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}