// db.createUser({
//   user: 'mongo',
//   pwd: 'mongo',
//   roles: [
//     {
//       role: 'readWrite',
//       db: 'lobsterdb',
//     },
//   ],
// });

db = new Mongo().getDB("lobsterdb");
db.createCollection('users', { capped: false });

db.users.insertMany([
{
 "Id": 1,
 "Username": "test",
 "Password": "test"
},
{
 "Id": 2,
 "Username": "Wolverine",
 "Password": "Wolverine"
},
{
 "Id": 3,
 "Username": "Raven",
 "Password": "Raven"
},
{
 "Id": 4,
 "Username": "Rogue",
 "Password": "Rogue"
},
{
 "Id": 5,
 "Username": "Magneto",
 "Password": "Magneto"
},
{
 "Id": 6,
 "Username": "Sabretooth",
 "Password": "Sabretooth"
},
{
 "Id": 7,
 "Username": "Pyro",
 "Password": "Pyro"
}
]);

db.users.find().forEach(printjson);