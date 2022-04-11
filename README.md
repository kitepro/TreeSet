# TreeSet

Its just a simple tree optimized for very specific needs.<br>
It stores elements in form of a tree but order is not maintained.<br>
You can access element by its index just like an array which is not possible with sets.<br>

<b><i>This tree was made specifically to access a random element from a set.<br></i></b>
So all of the following operations are done in O(logN) :<br>
<ul>
  <li>Add</li>
  <li>Index</li>
  <li>Remove</li>
</ul>

[Keep in mind this is a set-like structure i.e order is not maintained after any 'Remove' operation]

PS : Also, you can set the order of the tree if you have an idea of number of elements your tree will be holding.
