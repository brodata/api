<div align="center">
    <a href="https://brodata.io/">
        <img src="https://brodata.io/img/brodata-hor-logo-01.png">
    </a>
</div>
<br />
<br />
<div align="center">
  
  [![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
  [![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)
  [![forthebadge](https://forthebadge.com/images/badges/for-you.svg)](https://forthebadge.com)
  
</div>

## Folder Structure

    .
    ├── BroData.API                 # API app
    │    ├── bin                    # 
    │    ├── Brokers                # Classes implementing DbContext in EntityFrameworkCore (didn't use in this (NoDB) version)
    │    ├── Controllers            # Classes implementing REST API GET functions
    │    │    └── v0
    │    ├── Data                   # Classes implementing Data Repositories
    │    ├── Models                 # Data models
    │    ├── csvs                   # All datasets for API
    │    └── Service                    
    │         └── v0                # Classes that describe the behavior of objects
    ├── XUnitTestBroDataApi         # Unit tests for api app
    └── BroData.sln                 # Visual Studio 2019 project file
    
    
 
</br>
</br>

## REST  API

### API Reference

 REST API URL |
 ------------- |
 `https://api.brodata.io/v0/ {method_name}` |

Method name | description 
------------|-------------
Cities |	US cities dataset
States |	US states dataset
Passwords |	Passwords generator
ISO3166 |	ISO3166 dataset + ccTLD
Names |	Names dataset
Surnames | 	Surnames dataset
DateTime | DateTime generator
telephones |	telephones generator
Emails |	Emails generator
Guid |	Guid generator

#### Giuds
| HTTP | Method name | Param description 
|---|--------------------|--------------------|
|`GET`|		`guids`					|	-	|
|`GET`|		`guids/{count}`					|	count - int. Sets the number of returned guids	(max 100)|


#### Cities
| HTTP | Method name | Param description 
|---|--------------------|--------------------|
|`GET`|		`cities`					|	-	|
|`GET`|		`cities/{id}`			|		id - int. Get city by id |
|`GET`|		`cities/{state}`	|   state - string. Get array cities by state code, like CA |

#### States
| HTTP | Method name | Param description 
|---|--------------------|--------------------|
|`GET`|		`states`					| -

#### Passswords
| HTTP | Method name | Param description 
|---|--------------------|----------------------------------------|
|`GET`|		`passwords`					        |		       -                 |
|`GET`|		`passwords/{len}`					| len - int. Sets password length (max 1024)                      	|
|`GET`|		`passwords/{len}:{bitmask}`			| bitmask - 4 flags, like 1011. Sets password generator params                           	|
|`GET`|		`passwords/{len}:{bitmask}/{count}`	|	count - int. Sets count passwd response (max 100)                    	|


> **bitmask** have four flags. In default all flags set in `1`

> **bitmask** can't have all flags set in `0`, like 0000

 `Flags:`
- `1000` : enable digits
- `0100` : enable lower chars
- `0010` : enable upper chars
- `0001` : enable special chars


#### ISO3166
| HTTP | Method name | Param description 
|---|--------------------|--------------------|
|`GET`|		`iso3166`					|	-	|

#### Names
| HTTP | Method name | Param description 
|---|--------------------|--------------------|
|`GET`|		`names`					|	-	| 

#### Surnames
| HTTP | Method name | Param description 
|---|--------------------|--------------------|
|`GET`|		`surnames`					|	-	| 

#### DateTime
| HTTP | Method name | Param description 
|---|--------------------|--------------------|
|`GET`|		`datetime`					|	-	| 
|`GET`|		`datetime/{format}`			|	format - char	| 

 **Available format for datetime:**

- `d` : "09/14/2020"
- `D` : "Monday, 14 September 2020"
- `f` : "Monday, 14 September 2020 04:24"
- `F` : "Monday, 14 September 2020 04:23:32"
- `g` : "09/14/2020 04:24"
- `G` : "09/14/2020 04:24:54"
- `m` : "September 14"
- `r` : "Mon, 14 Sep 2020 04:25:14 GMT"
- `s` : "2020-09-14T04:25:21"
- `t` : "04:25"
- `T` : "04:25:34"
- `u` : "2020-09-14 04:25:54Z"
- `U` : "Monday, 14 September 2020 04:26:03"
- `y` : "2020 September"

#### Telephones
| HTTP | Methods name | Param description 
|---|--------------------|--------------------|
|`GET`|		`telephones`					|	-	|
|`GET`|		`telephones/{count}`					|	count - int. Sets the number of returned telephones	(max 100)|

#### Emails
| HTTP | Methods name | Param description 
|---|--------------------|--------------------|
|`GET`|		`emails`					|	-	|