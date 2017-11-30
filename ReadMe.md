 ASP.NET MVC Core GraphQL sample

URL: localhost:<portNumber>/graphql

Query Sampling

- Getting Schema -

query LearnAboutSchema {
  __schema {
    queryType {
      fields {
        name
        description
      }
    }
		 types {
      name
      kind
    }
  }
}

- Getting News by category id -

{ 
 "query":
  "query{
     news(id:1){
       id 
       name
       category{
       	name
       }
     }
   }"
}
