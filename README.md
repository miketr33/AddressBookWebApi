<h2>Step 2 - Web API</h2>
This web api forms step 2 of the Address Book tech test. 

When you run this solution on it's own you can call the endpoints using the Swagger UI (generated on startup in your browser), or with Postman (or similar).

<h3>Companion Blazor App</h3>
This solution forms 1 of 2 parts. The other part is a Blazor web app that consumes this web api. 

To access the blazor solution, please got to this repo: [Blazor App - master branch](https://github.com/miketr33/AddressBookTechTest) and clone the latest from the master branch. 

<h2>To run locally:</h2> 
1. Open both solutions in 2 instances of your IDE.
2. Run the Web Api solution (you will see the Swagger UI loaded when it is ready).
3. Run the Blazor app (another browser window will open and you will see a simple blazor web page.

Note: Validation has not yet been fully implemented so for both the Post and Put's you must ensure your json is valid before passing. In addition to the sample JSON, an Id field has been added. This will take any valid integer. 

If you experience any issues getting the two parts to communicate, you may need to adjust the port configurations in program.cs for each solution.

<em>All work completed by Mike Tree 2024</em>
