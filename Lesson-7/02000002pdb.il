// Type: Lesson_7.Program 
// Assembly: Lesson-7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CADD4EE-C9F2-4A6A-BD60-DF7CE67D6851
// Location: C:\Games\Новая папка\Lesson-7\bin\Debug\Lesson-7.exe
// Sequence point data from C:\Games\Новая папка\Lesson-7\bin\Debug\Lesson-7.pdb

.class private auto ansi beforefieldinit
  Lesson_7.Program
    extends [mscorlib]System.Object
{

  .method private hidebysig static void
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 2
    .locals init (
      [0] string secret,
      [1] string input,
      [2] bool V_2
    )

    // [12 9 - 12 10]
    IL_0000: nop

    // [13 13 - 13 52]
    IL_0001: ldstr        "some secret password"
    IL_0006: stloc.0      // secret

    // [14 13 - 14 50]
    IL_0007: ldstr        "Enter password:"
    IL_000c: call         void [mscorlib]System.Console::WriteLine(string)
    IL_0011: nop

    // [15 13 - 15 47]
    IL_0012: call         string [mscorlib]System.Console::ReadLine()
    IL_0017: stloc.1      // input

    // [16 13 - 16 33]
    IL_0018: ldloc.1      // input
    IL_0019: ldloc.0      // secret
    IL_001a: call         bool [mscorlib]System.String::op_Equality(string, string)
    IL_001f: stloc.2      // V_2

    IL_0020: ldloc.2      // V_2
    IL_0021: brtrue.s    IL_0030

    // [17 13 - 17 14]
    IL_0023: nop

    // [18 17 - 18 47]
    IL_0024: ldstr        "Welcome!"
    IL_0029: call         void [mscorlib]System.Console::WriteLine(string)
    IL_002e: nop

    // [19 13 - 19 14]
    IL_002f: nop

    // [21 13 - 21 32]
    IL_0030: call         string [mscorlib]System.Console::ReadLine()
    IL_0035: pop

    // [22 9 - 22 10]
    IL_0036: ret

  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [mscorlib]System.Object::.ctor()
    IL_0006: nop
    IL_0007: ret

  } // end of method Program::.ctor
} // end of class Lesson_7.Program
