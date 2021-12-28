# ModelCreator.CLI
Create a simple C sharp model based upon console string
download the code 
dotnet build.
dotnet pack
dotnet tool install --global --add-source ./nupkg modelcreator.cli

there is a slight issue when defining the comma seperated values using single quotes only seems to output the first couple of values, 
I will need to create an issue for this.

example modelcreator -o sample.cs -s "Id,First Name,Surname,Address Line 1,Address Line 2"

