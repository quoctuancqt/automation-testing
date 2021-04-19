# Overview
This repository uses to demo how to run automation test using [Selenium](https://www.selenium.dev/documentation/en/getting_started/) and  [Selenium Grid](https://www.selenium.dev/documentation/en/grid/).

# Usage

***Note:*** *Before you run into this example, make sure you install [Docker](https://www.docker.com/) and [docker-compose](https://docs.docker.com/compose/).*

1. Run `docker-compose up` to install all neccessary resource.
2. Go to `C:\Windows\System32\drivers\etc` and add a row to `host` file like this
```
[YOUR_IP_ADDRESS] testserver.local
```
3. Goes to `Automation.Test\Automation.Test.Sample Uses` directory and run dotnet command `dotnet test` to execute the test.

# How to build your own test case?
1. In `Automation.Test.Sample` project, create your test page inherit from `PageBase` and `IPageObject`. This includes all web element and all method of your page. <br>
2. Open `Pages.cs` then add your page object to this class. This is a wrapper class includes all test page object of your website.
3. Create your scenario class inherit from `IClassFixture<SampleFixture>` then define your test case.
***Note:*** *You can create your own (Fixture)[https://xunit.net/docs/shared-context] class.*
