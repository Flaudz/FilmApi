﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using static FilmApi.MovieConstructor;
using static FilmApi.CastConstructor;
using static FilmApi.ActorProperties;
using System.Xml;

namespace FilmApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Velkommen til Film Databasen. Vælg hvad dit valg er");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1: Skriv en title på en film du vil se nemmere på");
                Console.WriteLine("2: Skriv navnet på en skuspiller du vil se nemmere på");
                Console.WriteLine("3: Luk lorted");
                Console.WriteLine();
                Console.Write("Valg: ");
                string valg = Console.ReadLine();
                if(valg == "1")
                {
                    MovieUrl();
                }
                else if(valg == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Navn på skuspiller: ");
                    string actorName = Console.ReadLine();
                    ActorInfo(actorName);
                }
            }
        }

        public static void MovieUrl()
        {
            Console.Clear();
            Information information = new Information();
            CrewInformation crewinformation = new CrewInformation();
            Console.Write("Hvad er filmens title: ");
            string movieUrl = Console.ReadLine();
            MovieConstructor.Root movies = information.GetMovies(movieUrl);
            Console.Clear();
            foreach (var movie in movies.results)
            {
                CastConstructor.Root crewInformation = crewinformation.GetCrew(movie.id.ToString());
                Console.WriteLine();
                Console.WriteLine("<<========================================================================>>");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Title: {movie.title}");
                Console.WriteLine();
                Console.WriteLine($"Release Date: {movie.release_date}");
                Console.WriteLine();
                Console.WriteLine($"Adult: {movie.adult}");
                Console.WriteLine();
                Console.WriteLine($"Description: {movie.overview}");
                Console.WriteLine();
                Console.WriteLine("Cast:");
                foreach (var human in crewInformation.cast)
                {
                    Console.WriteLine($"Actor: {human.name} | {human.character}");
                }
                Console.WriteLine("<<========================================================================>>");
            }
                Console.ReadLine();
                Console.Clear();
        }

        public static void ActorInfo(string name)
        {
            Console.Clear();
            ActorInformation actorInformation = new ActorInformation();
            ActorProperties.Root actors = actorInformation.GetActor(name);
            foreach (var actor in actors.results)
            {
                Console.WriteLine("<<========================================================================>>");
                Console.WriteLine($"Name: {actor.name}");
                Console.WriteLine();
                Console.WriteLine($"Known For: {actor.known_for_department}");
                Console.WriteLine();
                Console.WriteLine("Movies:");
                foreach (var movie in actor.known_for)
                {
                    Console.WriteLine($"Title: {movie.title} | ReleaseData: {movie.release_date}");
                }
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
