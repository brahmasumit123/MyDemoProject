Feature: HomePage
	In order to validate Search Page
	As a external User
	I want to Search Result Page

@External
Scenario Outline: Validate Search Page for IFRS 17 in External Site 
	Given User Navigates to application <SiteType> Home page
	When User click on to search button Home page
	Then User Enter the search input <searchText> Home page
	And User Verify the search Result <Result1> Home page
	And User Verify the search Result <Result2> Home page
	And User Verify the search Result <Result3> Home page
	And User click on to search button Home page
	And User Verify the search Result <Result1> Search page
	And User Verify the search Result <Result2> Search page
	And User Verify the search Result <Result3> Search page
	And Test completed Successfully
	Examples: 
| SiteType | searchText | Result1                                               | Result2         | Result3   |
| External | IFRS 17    | Interim results for the six months ended 30 June 2022 | Gavin Wilkinson | John King |

@External
Scenario Outline: Validate Conact Page for Bermuda office Address in External Site 
	Given User Navigates to application <SiteType> Home page
	When User click on to Menu button Home page		
	Then User click on to Conact button Menu page
	And User Verify the Contact Address  <searchText> Contact page
	Then Test completed Successfully
	Examples: 
| SiteType | searchText                                                                                      |
| External | Ground Floor, Chesney HouseThe Waterfront, 96 Pitts Bay Road,Pembroke, Hamilton HM 08, Bermuda |