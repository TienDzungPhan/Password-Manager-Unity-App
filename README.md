# Password-Manager-Unity-App
A Unity Application written in C#

I created this application as a programming assignment in college. Games with Unity are pretty popular, so I wanted to make something different.

The application has 5 main features: Password Generating, Storing, Listing, Expiration Reminding, and Main App Authentication.

## Password Generating
The application enables users to either choose their passwords or use the auto-generating feature. With this feature, users can choose the passwords length and the type of characters they want in their passwords. Then the application auto-generates random strings based on those conditions.

## Password Storing
All created passwords and related information are encrypted by the AES algorithm, using the RijndaelManaged Class. The application then stores them in Unity's PlayerPrefs as JSON strings.

## Password Listing
The application decrypts all data with the AES algorithm before listing them in the Home Screen. The listing feature uses Unity's Prefab Prototype.

## Password Expiration Reminding
The application saves all passwords with timestamps of the modification. This information shows how long the password last changed. If the password remains unchanged for a particular amount of time, the application displays a warning message to remind users to change their passwords periodically. Reminding time can be set on Settings Screen, with 6 options: Never, every 30 days, 60 days, 90 days (Default), 180 days, and 365 days.

## Main App Authentication
The application provides a Log-in feature with a Master Password to enhance security. Users can create Master Password at first launch or whenever they decide to change it in Setting Screen. The application then hashes and stores it at PlayerPrefs. Master Password also acts as a parameter in the encrypting algorithm of the application.
