
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0




// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern System
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly 'Lesson-7'
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 08 4C 65 73 73 6F 6E 2D 37 00 00 )          // ...Lesson-7..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 08 4C 65 73 73 6F 6E 2D 37 00 00 )          // ...Lesson-7..
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 32 32 00 00 )                            //  2022..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 32 64 34 37 37 38 34 62 2D 39 37 30 37   // ..$2d47784b-9707
                                                                                                  2D 34 35 38 32 2D 39 64 62 36 2D 38 32 33 65 62   // -4582-9db6-823eb
                                                                                                  65 63 39 66 30 62 32 00 00 )                      // ec9f0b2..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1C 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 37 2E 32 01   // ,Version=v4.7.2.
                                                                                                        00 54 0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73   // .T..FrameworkDis
                                                                                                        70 6C 61 79 4E 61 6D 65 14 2E 4E 45 54 20 46 72   // playName..NET Fr
                                                                                                        61 6D 65 77 6F 72 6B 20 34 2E 37 2E 32 )          // amework 4.7.2
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module 'Lesson-7.exe'
// MVID: {4CADD4EE-C9F2-4A6A-BD60-DF7CE67D6851}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00020003    //  ILONLY 32BITPREFERRED
// Image base: 0x0BB20000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Lesson_7.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Размер кода:       55 (0x37)
    .maxstack  2
    .locals init ([0] string secret,
             [1] string input,
             [2] bool V_2)
    IL_0000:  nop
    IL_0001:  ldstr      "some secret password"
    IL_0006:  stloc.0
    IL_0007:  ldstr      "Enter password:"
    IL_000c:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0011:  nop
    IL_0012:  call       string [mscorlib]System.Console::ReadLine()
    IL_0017:  stloc.1
    IL_0018:  ldloc.1
    IL_0019:  ldloc.0
    IL_001a:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_001f:  stloc.2
    IL_0020:  ldloc.2
    IL_0021:  brfalse.s  IL_0030

    IL_0023:  nop
    IL_0024:  ldstr      "Welcome!"
    IL_0029:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_002e:  nop
    IL_002f:  nop
    IL_0030:  call       string [mscorlib]System.Console::ReadLine()
    IL_0035:  pop
    IL_0036:  ret
    IL_0037:  call       void [mscorlib]System.Console::WriteLine(string)
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class Lesson_7.Program

.class private auto ansi sealed beforefieldinit Lesson_7.Properties.Settings
       extends [System]System.Configuration.ApplicationSettingsBase
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string,
                                                                                      string) = ( 01 00 4B 4D 69 63 72 6F 73 6F 66 74 2E 56 69 73   // ..KMicrosoft.Vis
                                                                                                  75 61 6C 53 74 75 64 69 6F 2E 45 64 69 74 6F 72   // ualStudio.Editor
                                                                                                  73 2E 53 65 74 74 69 6E 67 73 44 65 73 69 67 6E   // s.SettingsDesign
                                                                                                  65 72 2E 53 65 74 74 69 6E 67 73 53 69 6E 67 6C   // er.SettingsSingl
                                                                                                  65 46 69 6C 65 47 65 6E 65 72 61 74 6F 72 09 31   // eFileGenerator.1
                                                                                                  36 2E 31 30 2E 30 2E 30 00 00 )                   // 6.10.0.0..
  .field private static class Lesson_7.Properties.Settings defaultInstance
  .method public hidebysig specialname static 
          class Lesson_7.Properties.Settings 
          get_Default() cil managed
  {
    // Размер кода:       11 (0xb)
    .maxstack  1
    .locals init ([0] class Lesson_7.Properties.Settings V_0)
    IL_0000:  nop
    IL_0001:  ldsfld     class Lesson_7.Properties.Settings Lesson_7.Properties.Settings::defaultInstance
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Settings::get_Default

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System]System.Configuration.ApplicationSettingsBase::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Settings::.ctor

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Размер кода:       21 (0x15)
    .maxstack  8
    IL_0000:  newobj     instance void Lesson_7.Properties.Settings::.ctor()
    IL_0005:  call       class [System]System.Configuration.SettingsBase [System]System.Configuration.SettingsBase::Synchronized(class [System]System.Configuration.SettingsBase)
    IL_000a:  castclass  Lesson_7.Properties.Settings
    IL_000f:  stsfld     class Lesson_7.Properties.Settings Lesson_7.Properties.Settings::defaultInstance
    IL_0014:  ret
  } // end of method Settings::.cctor

  .property class Lesson_7.Properties.Settings
          Default()
  {
    .get class Lesson_7.Properties.Settings Lesson_7.Properties.Settings::get_Default()
  } // end of property Settings::Default
} // end of class Lesson_7.Properties.Settings


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 C:\Games\Новая папка\Lesson-7\ildasmLesson-7.res
