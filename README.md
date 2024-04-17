Library for unsigned long numbers any length (by default 2048 bits in binary) in 2^32 number system. LongInt supports basic operations: 
- Adding two LongInt's (+);
- Subtracting two LongInt's (-);
- Multiplication of LongInt and regular uint(not commutative) (LongInt * uint);
- Multi-bit multiplication of two LongInt's (LongInt * LongInt);
- Division two LongInt's (/);
- Modulus one number by another (%);
- Bit shifts left and right (<<, >>), which represents multiplying or division by 2^32;
- The power of one LongInt to another LongInt (.Pow)
Also have modulo operations using Barrett reduction, operation for calculating GCD of two number, using binary algorithm, and calculating LCM based on GCD.
Supports convert from LongInt to hex string, from LongIntBit into binary, and from LongInt to LongIntBit, and vice verse.

