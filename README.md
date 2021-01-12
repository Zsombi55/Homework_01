# FTIT C-Sharp Homework Assignments
FTIT C# .NET course, 1-st homework repository.

> 20201203 ~ 07

* __A1 (DividedString),__ done, plus.

_As I understand the instructions:_ it is done so long functions in the code can be swapped out in the `main` by eg.: in/out commenting functions, without manual value changes or read /wrtite function edits.

_My plus:_ the user can make the choice of separator.

* __A2 (StringTable),__ done,  with instructor assistance.

_As I understand the instructions:_ get 3 or more lines of texts sprinkled with 2 of a set type of delimiter (I chose the pipe, "|"), then print it all like a table, formatting it either using the `string.Format` or the `string.Interpolation` functions.

Had an issue with storing the input; trying to do it the way I've been was not the way to go about it. After more than 10 hours requested instructor assistance.

* __A3 (StringFinder),__ done.

_As I understand the instructions:_ get a text & 1 search word, literal search of whole words, print total count of search word occurence.

_The intended instructions:_ get a text & 1 search word, search of the word as a character set, print total count of set occurence regardless of its position in the text (could be part of a word too).

The problem: for example "az" matches the character pair regardless of placement (even part of a longer word), "Az" matches only exactly, "aZ" & "AZ" never match unless the text contains such character pairs. Tried applying `.ToLower()` but I did not see any effect.

Got instructor assistance, found out the instructions were unclear /incorrect therefore I understood a different goal than what was intended. While what I strived for is only somewhat usable (still needs fixing for specifics) the actual goal was in fact solved by myself along the way.

* __A4 (ReverseString),__ done.

_As I understand the instructions:_ get a 1 word text from user, reverse order the characters, compare result with original text, return true/false on match.

* __A5 (IsThereInput),__ done,  by Instructor , after collective request, during lesson 20201207.

_As I understand the instructions:_ get 3 text, check content, for each input `if null` print "no content" `else` return input; USE NOT: loop instructions (eg. if, for), try "??" when reading.

> 20201209 ~ 16

* __A6 (LoginLoops),__ done.

_As I understand the instructions:_ store the expected input values in code, ask input and check validity, if they match print the predefined message "Welcome!", if there is no match print so & ask again; 3 versions: `WHILE`, `DO-WHILE` and `FOR`.

* __A7 (BasicVectoring),__ done.

_As I understand the instructions:_ read integers in vector, do calculations/manipulations: smallest & largest item index, sort as-& descending, print subvector of even & odd items, print a subvector with items of the original's section starting from a user given index and length; use a function like `string.Substring(index, length)`.

> 20201214 ~ 16

* __A8 (BasicMatricing),__ done.

_As I understand the instructions:_ get a matrix, print the secondary diagonal line, transpose the matrix and print result, check for identity matrix.

> 20201216 ~ 20210106 ~ 20210120

* __A9 (ArrayElementSummer),__ done.

_As I understand the instructions:_ get numbers from the user into an array, add the 1st element to 0, add thenext one to it etc., make new array, put results in it, then print it.

* __A10 (IsSubsequence),__ done.

_As I understand the instructions:_ get 2 int arrays "a" & "b", check if "b"'s elements are part of "a" in the same order !!, true/false.

* __A11 (BasicFindPairs),__ done.

_As I understand the instructions:_ get an int array, double iterate: check  i  against  j  (start i+1), while  i < j  , print match count; eg. `1 2 3 1 1 3 = 4 [(0,3),(0,4),(2,5),(3,4)]`.

* __A12 (BasicPathingLabyrinth),__ almost done, the stepping function that follows the weighted cells stops after 5 or so steps.. `will look into it asap`.

_As I understand the instructions:_ "basic labyrinth path finder"; "0" for clear cell, "-1" for wall, "int.MaxValue" for occupied, and "int.MinValue" for exit. Square map data from user-input /txt file into matrix, mark clear cells with values in mirror matrix, using these values find shortest path out, print the path as a list of coordinates.

Got some instructor assistance before the holidays printing out the data from the file.

Disregarded certain directives, I think: I did not use "int.MinValue" while "int.MaxValue" not as requested. Things seem simpler this way. It works, mostly.

> 20210111 ~ 20210127

* __A13 (RecursiveVectoring),__ done.

_As I understand the instructions:_ have or get a number array (a vector), then without predefined loops such as FOR, FOREACH, WHILE, etc.: find the smallest and the largest values - using Recursion.

The User has to input the elements but the vector length is fixed at 10.
