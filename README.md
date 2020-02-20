# Password-Manager-Unity-App
A Unity Application written in C#

I created this application as a programming assignment in college. Games with Unity are pretty popular, so I wanted to make something different. 

The application has 5 main features: Password Generating, Storing, Listing, Expiration Reminding and Main App Authentication.

## Password Generating
The application enables users to either choose their own passwords or use the auto-generating feature. With this feature, users can choose the passwords length and the type of characters they want in their passwords, then the application will auto-generate random strings based on those conditions. 

## Password Storing
All created passwords and related information will be encrypted by the AES algorithm, using the RijndaelManaged Class. The application will then store them in Unity's PlayerPrefs as JSON strings.

## Password Listing
The application will decrypt all data with AES algorithm before listing them in the Home Screen. The listing feature is done by using Unity's Prefab Prototype.

## Password Expiration Reminding
All passwords are saved with timestamps of the modification. This information is used to show how long since the password last changed. If the password remains unchanged for a particular amount of time, a warning message will be displayed to remind users to change their passwords periodically. Reminding time can be set on Settings Screen, with 6 options: Never, every 30 days, 60 days, 90 days (Default), 180 days and 365 days.

## Main App Authentication
The application provides Log-in feature with a Master Password to enhance security. Master Password is created at first launch or whenever users decide to change it in Setting Screen. It is hashed and stored at PlayerPrefs. It also acts as a parameter in the encrypting algorithm of the application.
