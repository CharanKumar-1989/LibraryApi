# LibraryApi

This Api lets you add books to the store and search the existing books with filter criteria. 
Only Admins can add books to the store, where as customers and admin both can search the books available in the store.

This Api requires user to be authenticated via the identity api (api/tokens).The identity api returns a JWT token which should be used to authenticate the calls to Library API
SampleURL:
http://{endpoint}/api/Books
http://{endpoint}/api/Books?bookName={bookName}&publisher={publisher}

Swagger document can be found in https://{endpoint}/swagger/ which will explain the requests and responses


# IdentityApi
This api allows the user to be authenticated.
It gets the emailID and password and returns a JWT token on successfull authentication.
For this sample api, few users with roles have been hardcoded in the api's code.

Sample Url:
http://{endpoint}/api/tokens?emailID={emailID}&password={password}
