Notify Me CI
============

[![Build Status](https://travis-ci.org/Badgerati/NotifyMeCI.svg?branch=master)](https://travis-ci.org/Badgerati/NotifyMeCI)
[![Build status](https://ci.appveyor.com/api/projects/status/xhjm5ra3ai0yf0ft?svg=true)](https://ci.appveyor.com/project/Badgerati/notifymeci)
[![Code Climate](https://codeclimate.com/github/Badgerati/NotifyMeCI/badges/gpa.svg)](https://codeclimate.com/github/Badgerati/NotifyMeCI)
[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/Badgerati/NotifyMeCI/master/LICENSE.txt)

Notify Me CI is a desktop/system tray application to notify you of CI tasks across varying Servers. And if you're wondering, yes the name is a pun on "Notice me senpai!"

Features
========

* Ability to add multiple CI servers (currently supports Jenkins and AppVeyor).
* Minimises to the system tray, notifying you of builds, fails and successes.

Installing Notify Me CI
=======================

Coming to Chocolatey soon.

Usage
=====

Notify Me CI is rather simple to use. Once you open the application you should navigate to the `Servers` tab (this will open as default if you have no servers setup). Here you'll be able to add server endpoints/credentials for the likes of Jenkins/AppVeyor.

Let's say you're adding a Jenkins server:

* Select the Server Type as Jenkins (notice the API Token field disappears, this is because Jenkins doesn't need it)
* Select a unique name, this will help you to identify the server later on in the `Jobs` tab.
* Enter the main view URL for Jenkins, such as `http://localhost:8080/` (or a sub-view if you wish)
* Select a poll frequency, in seconds. This tells the background process how often to poll Jenkins for updates.
* Click `Add Server`.

There will be some validation run when you add the server, but assuming all goes well the jobs will be collected from the server when the background process next attempts to poll.

After that, you can minimise the application to the system tray, and it'll continue polling in the background, alerting you to builds, failures, successes, aborts, etc.

Note: The process for AppVeyor is basically identical to the above however, the URL when AppVeyor is select is defaulted to the main projects page; your API token will also *need* to be supplied.

To Do
=====

* Add Travis CI and TeamCity.
* Maybe make the GUI look prettier?

Bugs and Feature Requests
=========================

For any bugs you may find or features you wish to request, please create an [issue](https://github.com/Badgerati/NotifyMeCI/issues "Issues") in GitHub.