Download the solution
Extract the zip
Navigate to the extracted folder in Command prompt

Instructions can be followed in either of 2 ways

1. I have written a batch file that cleans, builds, runs unit tests and executes the solution with provided input file. To execute just run the below command

family.bat <absolute_path_to_input_file>

2. Execute the below commands to run the code

cd geektrust
dotnet build -o geektrust
dotnet test
dotnet geektrust/geektrust.dll <absolute_path_to_input_file>

EDIT - 2
---------------------------------------------------
Below is the feedback from 2nd checkin and the changes made respectively

Areas of Improvement:
Behaviour methods like AddChildToCouple/SetSpouse don't read well and could have been renamed. (Ex: Hey John, when are you setting a spouse?)
	I have renamed the behaviour methods to BearChild/Marry so that the actions relates the verbs to real world situation. (Ex: Hey Satvy, Have you bear a child?)

Creation of the family tree seed data could have been extracted out to a file making it easier to change if needed. (ConstructFamilyTree() still exists). Family class has multiple public constructors which could have been avoided.
	I have already done the seed data creation from a file in my second submission but didn't remove the dead code. Now I deleted the unused code and the unused public constructor. 

The relationship logic could have been moved to the Person class as behaviour.
	I have moved the relationship logic to person class as behaviour.

Duplicate code such as below in RelationshipsHelper could have been avoided. Logic in Helper classes is generally a bad code smell, since they tend to hog domain logic over a period of time.

1. if (personName == null || !familyMembers.ContainsKey(personName))
{
siblings.Append(Messages.PERSON_NOT_FOUND);
}
2. Append(p.Name + " ");

	I have removed the duplicate code mentioned and removed the class RelationshipsHelper as it is not required anymore.
	


EDIT - 1
---------------------------------------------------
Below is the feedback from 1st checkin and the changes made respectively

Good attempt at solving the problem. Class(es) like Person, Family has been identified. I/O works as expected.

Areas of Improvement:
The command logic in the main class could have been delegated elsewhere making it easier to support more commands in the future.
	Delegated this to FileProcessor class. Created a interface ICommandProcessor(FileProcessor is derived from this) so that it is easier to support any other type of input in future.

Duplicate code for relationships like GetSisterInLaws/GetBrotherInLaws, GetMaternalUncles/GetPaternalUncles, .. could have been avoided.
	Removed the duplicate code and sent a parameter gender so that code duplication is removed.

The relationship logic could have been moved to the Family class as behaviour.
	Moved it to Family class and removed Relationships class.

Person class breaks encapsulation by providing public getters and setters.
	Removed public setters and made sure encapsulation is followed.

Behaviour methods like AddChild/AddSpouse don't read well and could have been renamed.
	Changed the method names.

Creation of the family tree seed data could have been extracted out to a file making it easier to change if needed.
	Added logic to construct family tree from a file. This is done using family constructor with file path parameter. 
