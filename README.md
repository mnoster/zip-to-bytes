# Convert Zip File to Bytes & Hash



## Development 

### MacOS
**Download Mono/CSC to compile and execute C Sharp Files on MacOS:**
- For Windows users there should be a compiler available already in you CMD Prompt.
- https://www.mono-project.com/download/stable/


Once installed close and reopen your terminal for access to `mono` and `csc`.


**To Run Script use mono**
```
mono ZipToText.exe
```

   - Creates a `temp/hash.txt` file
   - Creates a `temp/bytes.txt` file

`/temp`: *make sure the temp dir is in the root of the project. It should be there if you cloned the repo. It should only have the* `.gitkeep` initially.

**The hash.txt that is created is the hash of the zipfile, later written to the `Verifications.sol` smart contract**


Whatever zip file you want to create a hash for, add it into the `/temp` directory and name it `allData.zip`.

   - You can name the zip file however you like, you'll just have to change it in the `ZipToTextFile.cs` code.
   - Make sure to set the name of the zip file variable in the `Main` function.

**To compile C# file use csc:**
```
csc ZipToTextFile.cs
```

**To Run Script use mono**
```
mono ZipToText.exe
```
