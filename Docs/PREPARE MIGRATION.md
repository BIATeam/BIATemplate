# Prepare Migration

## If it was not done at the delivery set tags on project BIATEMPLATE at the last commit of the delivery
1. To have the full log history open powersheel:
```ps
cd ...\BIATemplate
git log --pretty=format:"%h - %an, %ad"
```
2. select the correct commit id corresponding to the date 
3. Create the tag directly in the azure devops interface:
https://azure.devops.safran/SafranElectricalAndPower/Digital%20Manufacturing/_git/BIATemplate/tags
4. Sync your local repository BIATemplate

## Create the git differential patch 
1. use git batch (V2.30.1 or higher) and run command (ex for V3.2.0 to V3.2.2):
```ps
cd "...\\BIATemplate"
git diff V3.2.0 V3.2.2 > ..\\BIADemo\\Docs\\Migration\\Patch\\3.2.0-3.2.2.patch
```

2. Copy the .patch file in BIADemo\Docs\Migration

## Add notice to apply the migration 
* in the migration document in folder BIADemo\Docs\Migration creation a migration file with folowing instruction (change the version number and remove the \ before ```):
```md
## AUTOMATIC MIGRATION
1. Apply the patch
* Copy the file [3.2.2-3.3.0.patch](./Patch/3.2.2-3.3.0.patch) in the project folder.
* Remplace BIATemplate by the name of your project
* Remplace biatemplate by the name of your project in lower case
* Run the following command in Git Batch
\```ps
cd "...\\YourProject"
git apply --reject --whitespace=fix "3.2.2-3.3.0.patch"
\```

2. Analyse the .rej file (search "diff a/" in VS code) that have been created in your project folder
=> It is change that cannot be apply automaticaly.
=> Apply manualy the change.
```

* Complete the migration document : Write custom change to apply to back and front.
...