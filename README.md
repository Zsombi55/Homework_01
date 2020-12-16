# FTIT C-Sharp Homework Assignments
FTIT C# .NET course, 1-st homework repository.

> 20201203 ~ 07

* __A1 (DividedString),__ done, plus.

_As I understand the instructions:_ it is done so long functions in the code can be swapped out in the `main` by eg.: in/out commenting functions, without manual value changes or read /wrtite function edits.

_My plus:_ the user can make the choice of separator.

* __A2 (StringTable),__ wip .. after literally 10 hours I still don't know how to store the input; maybe trying to do it the way I've been is not the way to go about it?

_As I understand the instructions:_ get 3 or more lines of texts sprinkled with 2 of a set type of delimiter (I chose the pipe, "|"), then print it all like a table, formatting it either using the `string.Format` or the `string.Interpolation` functions.

* __A3 (StringFinder),__ somewhat done, but not quite.

_As I understand the instructions:_ get a text & 1 search word, literal search of whole wordsprint total count of search word occurence.

The problem: for example "az" matches the character pair regardless of placement (even part of a longer word), "Az" matches only exactly, "aZ" & "AZ" never match unless the text contains such character pairs. Tried applying `.ToLower()` but I did not see any effect.

* __A4 (ReverseString),__ done.

_As I understand the instructions:_ get a 1 word text from user, reverse order the characters, compare result with original text, return true/false on match.

* __A5 (..),__ done,  by Instructor , after collective request, during lesson 20201207.

_As I understand the instructions:_ get 3 text, check content, for each input `if null` print "no content" `else` return input; USE NOT: loop instructions (eg. if, for), try "??" when reading.

> 20201209 ~ 16

* __A6 (LoginLoops),__ done.

_As I understand the instructions:_ store the expected input values in code, ask input and check validity, if they match print the predefined message "Welcome!", if there is no match print so & ask again; 3 versions: `WHILE`, `DO-WHILE` and `FOR`.

* __A7 (BasicVectoring),__ done.

_As I understand the instructions:_ read integers in vector, do calculations/manipulations: smallest & largest item index, sort as-& descending, print subvector of even & odd items, print a subvector with items of the original's section starting from a user given index and length; use a function like `string.Substring(index, length)`.

> 202012014 ~ 16

* __A6 (BasicMatricing),__ done.

_As I understand the instructions:_ get a matrix, print the secondary diagonal line, transpose the matrix and print result, check for identity matrix.
