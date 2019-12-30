@echo off
cd geektrust
echo Starting to clean the solution
echo ----------------------------------------------------
dotnet clean
echo ----------------------------------------------------
echo Cleaning the Solution is completed
echo Starting to build the application
echo ----------------------------------------------------
dotnet build -o geektrust
echo ----------------------------------------------------
echo Build Completed
echo Starting Unit tests execution
echo ----------------------------------------------------
dotnet test
echo ----------------------------------------------------
echo Test cases execution completed
echo Starting code execution with input file
echo ----------------------------------------------------
dotnet geektrust\geektrust.dll %1
echo ----------------------------------------------------
echo Code execution completed
echo ----------------------------------------------------
cd ..