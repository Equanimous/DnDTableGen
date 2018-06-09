# DnDTableGen

Small application whose purpose is to allow the user to select files containing newline delimited objects, and convert that data into a randomized table where each member has an associated probability for the purposes of rolling a d100

Note that this program is not intended to be beautiful; it's just something bare-bones thrown together to aid in DnD prep

TO-DO:
1) Figure out what to do when more than 100 elements exist
2) Fix the abomination that is the scale code when 100 % dataList.count != 0
3) General error checking for I/O and type casting
4) Add logic to handle when multiple files are selected