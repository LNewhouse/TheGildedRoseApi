# TheGildedRoseApi
API Test for the folks at EP

API Requirements (Tested using Postman)
````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
1) Retrieve the current inventory (i.e. list of items)

Can be obtained by making a get call to the localhost/api/inventory

2) Buy an item (user must be authenticated)

Authentication can be performed by making a post call to the localhost/api/login with a Json object containing the following
{ "Username" : "ValeeraSanguinar", "Password" : "BloodElf" } //Matches the login object with our list of registered users
//This returns a JWT if successful that contains a UserId that is unique to that user

A transaction can be performed by making a post call to the localhost/api/transaction with a json object containing the following
{ "ItemId" : 1, "Quantity" : 5 } //Creates a transaction if the UserId is passed back via JWT
//Transaction is then validated and commited.
````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

Questions
````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
1) How do we know if a user is authenticated?
We know the user is authenticated if they successfully pass in a JWT that has a UserId claim. This can only be obtained if they are succesfully vailidated by the LoginController. This LoginController matches the Username and Password passed in via Json object, and, if they exist, then we create a JWT and add the User's unique UserId as a claim. When the user then tries to purchase and item we then read the users JWT, and, if a UserId claim is found, we create a transaction based on the UserId and the purchase order that is passed in as a Json object.

2) Is it always possible to buy an item?
No it is not always possible to buy an item. The user must have succesfully logged in to have obtained a JWT. This JWT will expire in 30 minutes, and has a UserId claim that will be examined upon arriving at the TransactionController. If the token is expired or the UserId is not present we bail out and return a HttpStatusCode.Forbidden. Additionally the purchase can fail if the user does not have sufficient funds to cover the purchase order.
````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

Deliverables Explanation
Choice of data format and why JWT was the authentication method of choice
Json was the data format chosen just because it is rather simple to use, robust, and lightweight. It was easy to pick up, and has several applications that can be used to test payloads on the api. Additionally it allows the use of JWT which makes authentication relatively simple to setup. Example includes purchasing an item. It is very easy to create a Json purchase order object { "ItemId" : 1, "Quantity" : 5 } and send that to the api. 
The JWT was chosen as the authentication choice because it allows easy configuration and 256 bit encryption. It allowed me to embed information into the token via a claim that could then be plucked out further down in the transaction bit of the deliverables. By creating a token that had a UserId claim, I was able to create a purchase order that only had the item to be purchased and its quantity. Since we require authentication to process a transaction, we receive the JWT. If the UserId portion of the JWT is present, then we know that it is a valid transaction. As stated before, it was also chosen for the 256 bit encryption, but in the case of this api that may have been a bit overkill. Primarily the JWT was chosen because it was lightweight easy to configure, and secure for the purposes of this test.
````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

If I have been unclear at any time during this readme, please feel free to ask me questions. This has been my first attempt at anything like this, so a bit of research was involved, and I have no doubt some of the methodologies or implementations I have are a bit unrefined. I encourage any feedback any of you may have towards this programming challenge.

Thanks for the challenge!
-Latham


