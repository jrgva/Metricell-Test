I've never used React so that lack of knowledge lead me to some questions and assumptions about the development of the API.

- The methods I've created for the API always return a List that must be shown, this is not an arbitray election. The instructions said that all changes should be reflected in
the front. I don't know how the front works, so, what makes sense to me is that you can call to a method, for example addEmployee and then always call listAll to show the update
in the employee list. I don't now if this is possible, or if you try to Add, you can only call for a method, so that's why I always show the list.

- The inputs for the differents endpoints have parameters and a one has a body, I know that both ways are correct, but I don't know which one is better for the integration with the front,
so I made a mix of them to have both possibilities.

- I supposed that the sum of all values with names beginning with A, B or C should be in another table, so that's why I've created one. But the sum should be presented only if the sum
is higher than a value. For that, there were two possibilities: the first one was to create a complex query that has the column or not depending on the value, the second one was to get always
the summatories values and show it or not but that control should be made on the front. (Again, I don't know if that's possible, but I suppose it is).
I think that carry that logic to a query is a bad practice, but I've made an alternative query where you can find that logic within the query, the better solution, in my opinion, is
to let the front control if the value must be shown or not.

- Inside the projet there is a POSTMAN collection with every request, so you can try each method
