Some basic information on Selenium can be found here:
https://help.crossbrowsertesting.com/selenium-testing/getting-started/best-practices-selenium-testing/
There is also a C# section in the sidebar with sample code

Make sure to keep packages updated in Visual Studio via Tools > NuGet package manager > manage NuGet packages for solution

### This guide is meant to be a rough tutorial to writing your first UI automation test

### What you need to get started:
1) Visual Studio

2) SpecFlow (install inside Visual Studio > Tools > Extensions and Updates…
-what you will use to creating and editing feature files

3) ReSharper: https://www.jetbrains.com/resharper/ 
-this is optional though highly recommended

---

#### Chapter 1 – Foundations: Feature files, Steps, Objects

Feature files, Steps, and Objects are the 3 big concepts you need to know to write UI automation tests.

##### Feature Files 
Format: *.feature

Please try to separate feature files into folders designating the category that they belong to. Please make sure you are adding new tests into the correct category outlined by the folders. This makes organizing your tests much easier.

Moving on, these files are the reason why you need SpecFlow. We will go into more detail about how to use SpecFlow to write your own files in the SpecFlow chapter. Right now, focus on how the feature file contains syntax that appears to be a bunch of sentences with no punctuation. These sentences are the “Steps” to the test. In other words, a feature file serves as an overview and an easy way to determine what the UI automation test is doing without digging through piles of code.

##### Steps
Format: *Steps.cs

These are the “Steps” those sentences in the feature file refer to. You don’t need to know too much about these except that their barebone structures are mostly auto-generated via SpecFlow. Note that you also need to edit the automatically generated steps to call the methods in the object files. You will learn how to do this step by step in the SpecFlow chapter, so don’t worry if it doesn’t make much sense now.

##### Objects 
Format: *.cs

Object files contain C# methods that reference the Selenium Webdriver. Selenium is the automation that actually manipulates the web browser through the test. These object files are usually where you do the majority of your coding. Part of the reason this tutorial exists because the documentation for C# Selenium online is lackluster, scattered, deprecated, etc.

##### Chapter 1 Summary: Feature files > Steps > Objects
Feature files reference the Steps in easy to understand English. The Steps contain the methods/functions from the Objects that controls the browser.

e.g. of naming conventions:
 Fun.feature > FunPageSteps.cs > FunPage.cs 

---

##### Chatper 1.5 – Using unique HTML attributes

Why use unique HTML attributes? They are HTML attributes that makes it easier for Selenium to find the right elements. We add in some unique attributes to any HTML elements of new features that may be used in a UI automation test. 

Selenium doesn’t actually NEED a special HTML attribute to find anything. Selenium can find elements by CSS or other HTML attributes like id. However, having some separate unique identifier provides us with the certainty that Selenium is selecting the right elements (i.e. other elements may share the same attributes and Selenium may interact with the wrong ones).

The names you give the unique HTML attributes should be easily identifiable in a format of your choice as long as it's consistent (e.g. camelCase): e.g. headerFunButton

---

#### Chapter 2 – ReSharper and Running UI Tests

ReSharper can be downloaded here:
https://www.jetbrains.com/resharper/
It comes with a 30-day trial, so you have a bit of time until you obtain an education license or a full one.
ReSharper does much more than what is listed in this chapter related to unit testing. Their documentation and other features can be found in the link above.

After you have ReSharper installed in Visual Studio, go enable the Unit Test Explorer window from:
ReSharper > Windows > Unit Tests

You can’t run the tests from the Solution Explorer! Right clicking a feature file and selecting Run SpecFlow Scenarios should throw an error! You need to use the Unit Test Explorer to run the UI tests properly.

The Unit Test Explorer is also different from the standard Test Explorer window that comes with Visual Studio. Don’t confuse them! I suggest you close the standard Test Explorer window since you won’t be using that very often now that you have ReSharper.

Note: If you have over a hundred UI tests so it’s easier to filter results through the search bar in the Unit Test Explorer instead of trying to sift through the many test categories or subcategories to find whichever UI test you want.

From the Unit Test Explorer window you can add tests to sessions by right clicking on the tests or test groupings. Sessions are very useful when you’re organizing tests to run. These sessions are viewable under the Unit Test Sessions window. A new sessions is automatically created when you run a test directly from the Unit Test Explorer. If a unit test session already exists, running a test from the Unit Test Explorer will add that test to the existing session. For example, I usually keep separate session tabs for UI tests I am currently working on, tests I am debugging, and tests that I may need to run for regression purposes after making any changes to steps or object files. If you want to remove tests from a session, right click and select Remove Selected Tests.

Within the Unit Test Sessions window there should be a little tool bar with buttons for running unit tests and debugging. Make sure that Show Output is enabled. If any assertions fail or if any exceptions are thrown, then the output will be displayed here. This output log is similar to what is displayed when the tests fail through Jenkins.

##### Chapter 2 Summary: ReSharper is the best!
Don’t confuse Unit Test Explorer from ReSharper with the standard Test Explorer or Solution Explorer.
You need the Unit Test Explorer to run your UI tests.
Super useful: Unit Test Explorer -> Unit Test Sessions -> Show Output 

---

#### Chapter 3 – SpecFlow and Writing Feature Files

It seems like you can only open feature files from the Solution Explorer. Sadly you can’t open them directly from ReSharper’s Unit Test Explorer. Right clicking > Go to Test Code takes you to SpecFlow’s auto-generated code.

##### Feature File Composition
Once you have the feature file open you can see that it is split into several parts:

1) Feature: 
At the very top of the feature file you will see something like a user story that succinctly describes the scenarios being run.

2) (Optional) Background:
These steps are repeated prior to every scenario or test case. So if your test scenarios have overlapping steps near the beginning, consider refactoring those steps into the Background.

3) Scenario: | Scenario Outline: + Examples:
This part contains the main bulk of your steps for your test cases. Scenarios can be upgraded to something called Scenario Outlines that references an Examples table at the bottom for data. If your test scenario repeated uses the same postal codes, product titles, addresses, dollar amounts, etc., consider refactoring your Scenario into a Scenario Outline with Examples. Note that Examples only work with Scenario Outlines and not with standard Scenarios. I have no idea why it’s set up like this. Remember to include the word Outline after Scenario if you are using Examples, otherwise the test will not run.

Writing Feature Files
As for SpecFlow syntax, you will see that some keywords When / Then / Given / And are also highlighted at the beginning of every line. Whichever word you choose doesn’t matter because we made our step definitions generic. I go into more detail about step definitions below. The main purpose of the syntax is to make it easier for you to read what the test scenario is doing. Make sure you choose the best fitting When / Then / Given / And keywords so the test scenario is as clear as possible.

Note: When you are editing SpecFlow steps, you may notice that the autocomplete is seems very fickle. This is because SpecFlow will only autocomplete existing steps when you backspace to a keyword like When / Then / Given / And.

To create a new step to use in a feature file:
1) Type out the step: e.g. Then I create a new step
2) Right click and select Generate Step Definitions
3) Click Copy Methods to Clipboard
4) Paste the Step Definition into your *Step.cs

        [Then(@"I create a new step")]
        public void ThenICreateANewStep()
        {
            ScenarioContext.Current.Pending();
        }

5) Make sure to make your Step Definitions generic. In the above example just change “Then” to “StepDefinition”:

        [StepDefinition(@"I create a new step")]
        public void ThenICreateANewStep()
        {
            ScenarioContext.Current.Pending();
        }

In the example above if we did not make the Step Definition generic, then we would only have been able to use that step after the SpecFlow keyword “Then”. Now that we made the change we can call the step from any of the keywords: When / Then / Given

##### Creating Feature Files
Right click whatever folder you would like to add the feature file:
Right Click > Add > New Item… >> Installed > Visual C# Items > SpecFlow Feature File

##### Chapter 3 Summary:
Remember to make your Step Definitions Generic!
Autosuggestion for Steps only works after you’ve backspaced to a SpecFlow keyword like When / Then / Given / And

---

#### Chapter 4: JavaScript in the Browser Console

##### Pausing JavaScript in your Browser
When you’re writing or debugging a test, you may run into problems with pop-ups or error messages or animations that disappear too fast for you see the element name that you’re supposed to grab.

In Chrome, you can open up your developer Console with F12. Once the developer options are open, you can hit F8 to pause the JavaScript (the screen should darken and show that the JavaScript is paused).

Ctrl + Shift + C will allow you to inspect an element. You can also use the little cursor icon in the top left to inspect an element. This will brighten the screen again but the JavaScript will still be paused.  You can use the element inspector to help you locate the details of those pesky elements that appear for only a brief moment.

##### QuerySelector
In the browser console you can use a JavaScript function to preview whether or not your Driver.FindElement(…) or Driver.FindElements(…) will successfully find an element.

Driver.FindElement(…) returns a single element. If there are multiple elements on the page, then it will return the first element. 
The corresponding JavaScript function is document.querySelector(…) 
e.g. document.querySelector(‘[data-qa-id=”NameGoesHere”]’) will return the first element that has a data-qa-id of NameGoesHere

If the element you want is actually the second element on the page, then you should probably use Driver.FindElements(…) combined with some LINQ query or a way to access the element you want.

Driver.FindElements(…) returns an array of elements.
The corresponding JavaScript function is document.querySelectorAll(…)
e.g. document.querySelectorAll(‘[class=”button”]’) will return an array of all elements that have the class name button

Note the syntax: ‘[Id-is-inside-brackets=”This is inside more quotations”]’ the whole parameter needs to be a string. If the syntax is wrong then the querySelector doesn’t work.

OVERALL: document.querySelector(…) is essentially the same as Driver.FindElement(By.CssSelector(…))

A great feature of document.querySelectorAll(…) is that you can peek into the details of the elements returned in the array such as the parent nodes or the HTML text.

This also means you can use document.querySelectorAll(…)[0].text or document.querySelector(…).text to preview whether or not your Selenium Driver will be able to find the text of the elements before you even run the test.

REMINDER: If you don’t like using querySelectors you can also preview your code via the Visual Studio Intermediate Window and breakpoints while running your UI tests in debugging mode.
The intermediate window allows you to run code while the code is paused.
e.g. Driver.FindElement(…).Text and will try to locate the element text specified
