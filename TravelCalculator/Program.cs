// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;
using static System.Convert;
using static SplashKitSDK.SplashKit;


string name ;
string userInput ;
double distance, time;
double speed ;
double remainingDistance, timeToDestination;
double totalDistance, totalTime;
Write("What is your name? ");
name = ReadLine();
WriteLine ($"Hello {name}. ");

Write("How far hae you travelled so far? Enter in km: ");
userInput = ReadLine();
distance = Convert.ToDouble(userInput);

Write("How long have you been travelling? Enter in min: ");
userInput = ReadLine();
time = ConvertToDouble(userInput);

speed = distance / (time / 60);

WriteLine();
WriteLine($"{name}, you are travelling at {speed} km/h.");
WriteLine();

Write("How far do you want to travel in total? Enter in km: ");
userInput = ReadLine();
remainingDistance = ConvertToDouble(userInput);
timeToDestination = (remainingDistance - distance) / speed * 60;

WriteLine($"You will take another {timeToDestination} minutes to reach your destination.");

totalDistance = distance + remainingDistance;
totalTime = time + timeToDestination;

WriteLine($"In total, you will have travelled {totalDistance} km in {totalTime} minutes.");

