Here will be all labs for special sections of computational math.

# Directories

## LongLibrary (lab 1)

Library for unsigned long numbers any length (by default 2048 bits in binary) in 2^32 number system. Also provided class LongIntBit (number in binary number system), whose only purpose is implement division to LongInt, so its functions are limited.

LongInt supports basic operations: 
- Adding two LongInt's (+);
- Subtracting two LongInt's (-);
- Multiplication of LongInt and regular uint(not commutative) (LongInt * uint);
- Multi-bit multiplication of two LongInt's (LongInt * LongInt);
- Division two LongInt's (/);
- Modulus one number by another (%);
- Bit shifts left and right (<<, >>), which represents multiplying or division by 2^32;
- The power of one LongInt to another LongInt (.Pow)

Also support convert from LongInt to hex string, from LongIntBit into binary, and from LongInt to LongIntBit, and vice verse.
