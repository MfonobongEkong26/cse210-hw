using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the first video
        Video video1 = new Video(
            "Introduction to C# Programming",
            "Mfonobong",
            600
        );

        video1.AddComment(new Comment("John", "This was a very helpful introduction."));
        video1.AddComment(new Comment("Sarah", "I learned a lot from this video."));
        video1.AddComment(new Comment("David", "The examples were easy to understand."));
        video1.AddComment(new Comment("Grace", "I am looking forward to the next lesson."));

        // Create the second video
        Video video2 = new Video(
            "How to Build a Website",
            "Web Developer Academy",
            900
        );

        video2.AddComment(new Comment("Michael", "The website design looks great."));
        video2.AddComment(new Comment("Anna", "I followed along and built my own website."));
        video2.AddComment(new Comment("Daniel", "Very clear explanation."));
        video2.AddComment(new Comment("Ruth", "Thank you for sharing this tutorial."));

        // Create the third video
        Video video3 = new Video(
            "Learning Object-Oriented Programming",
            "Code Master",
            750
        );

        video3.AddComment(new Comment("Peter", "The explanation of classes was excellent."));
        video3.AddComment(new Comment("Joy", "This made abstraction easier to understand."));
        video3.AddComment(new Comment("Samuel", "I really enjoyed this lesson."));
        video3.AddComment(new Comment("Esther", "Great examples and explanations."));

        // Create the fourth video
        Video video4 = new Video(
            "Programming with Classes",
            "Tech Learning Channel",
            820
        );

        video4.AddComment(new Comment("Chris", "This is exactly what I needed."));
        video4.AddComment(new Comment("Mary", "The examples were very useful."));
        video4.AddComment(new Comment("James", "I will practice these concepts."));
        video4.AddComment(new Comment("Linda", "Excellent programming tutorial."));

        // Put all videos into a list
        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3,
            video4
        };

        // Display information about each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            video.DisplayComments();

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
    }
}