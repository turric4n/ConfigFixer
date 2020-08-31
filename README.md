Application config environment fixer for Windows.

PROS :

- Works with zip files
- Works with multiple environments

CONS :

- Depends of .net core 3

Example :

We want to deploy into multiple environments, but our application behaviour is to load config.yml and doesn't know anything about environment...

So we will need the following to work with :

1. Config files for each environment :

  - Test (config.test.yml)
  - Production (config.pro.yml)
  - Production2 (config.pro2.yml)

2. ConfigFixerByEnv executable

3. Set your environment switch into your OS like - set ENVIRONMENT=Test 

4. The next command line :                     

ConfigFixerByEnv.exe -s "config" -e "ENVIRONMENT" -r ".yml" -l "." -d "config.yml"

----------------------------------------------------------------------------------

Modifiers : 

// Delete destination if exists
-m (Additional)
// Source configuration file name
-s (Mandatory)
// Destination file path
-d (Mandatory)  
//Environment variable
-e (Mandatory)  
// First additional environment variable
-t (Additional)
// Second additional environment variable
-x (Additional)
// Environment variables to file separator 
-l (Mandatory)
// Destination File extension 
-r (Additional)



	