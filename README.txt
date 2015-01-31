ChatTestTask
============

Task was:
--------------

Create a simple chat page in asp.net, using c#.
Fetch new chat messages from your choice of data source (xml, database, textfile or similar).
Make use of ajax (or similar) to refresh when new chat messages arrive. Pick your choice of framework.

Requirement 
	- There should a list of the chat posts
 	- It should be possible to post new chat posts.
	- The chat page will need to work on various systems, such as desktop (pc, mac) with large screens but also mobile such as ios/android with small screens.

Prerequisites
	- The chat page will be read by several thousand users simultaneously, but rather few will write posts. 
	- The code will run in a web farm (load balanced with several web servers).

Other
	- If there are some tasks that you would like to do but don't have time for during this time framed task, please write down what you would normally have done.
	- Don't spend more than a couple of hours on this task. Keep it simple.
	- Don't spend a lot of time making it pixel perfect, the important here is to see how you write code. Both frontend and backend code.
	- You don't need to create authentication for the chat.

My solution description:
--------------

1. Solution implements very simple multi-user chat web application. To emulate multi-user environment you have to copy application URL to several web browser instances, so you will be able to send chat messages from one browser window to another.
2. Soulution doesn't support user authentication.
3. Solution is based on next technologies:
    - .NET 4.5                              - as main platform
    - ASP.NET MVC 4                         - as webb app hosting
    - ASP.NET SignalR                       - to simplify implementation of "real-time" application behavior
    - Entity Framework 6.1 (Code First)     - as a basement of data access layer
4. ASP.NET SignalR is based on jQuery 2.0.3, so solution must be supported both by desktop and mobile browsers which are supports jQuery.
5. Template of Data Access Layer architecture based on EF has been taken from real project. DAL implements Unit Of Work pattern in its simplest form.
6. (LocalDb)\v11.0 used as application data source.

User's guide:
--------------

1. After application start you will have to define your chat user nickname in pop-up window or leave default 'Anonymous' name.
2. After your enter you nickname you will see chat window consists of:
    2.1. Test field for new messages.
    2.2. Send message button.
    2.3. Chat log.
3. Each time user enter the chat he/she will:
    3.1. Receive greeting message and date of his last appearance in the chat.
    3.2. List of latest 20 messages from other users published in the chat.
4. To emulate multi-user interactions you have to copy application URL and paste in address string of another instance of web-browser. So users will be able to send messages to each other.


TODO:
--------------

1. This application is nearly my first ASP.NET application, so it has very simple and not optimal UI part.
2. Due to Backend part has been taken from real project it was significantly simplified. Repositories structure and Unit Of Work parts could be improved a lot.
3. Application code contains hard coded values to simplify solution. In real solution such values must be placed in resources or generated in dynamic manner or should come from UI or config files.
4. Application have no unit tests coverage, but due to DAL decoupled from UI it is possible to create unit tests.
5. Application uses (LocalDb)\v11.0 database as a datasource. MS SQL Express or MS SQL Server could be used instead.
