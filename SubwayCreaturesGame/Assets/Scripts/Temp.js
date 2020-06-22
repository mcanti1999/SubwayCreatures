const mongoose = require("mongoose"),
 Subscriber = require("./models/subscriber");
mongoose.connect(
 "mongodb://localhost:27017/choresplit_db",
 {useNewUrlParser: true}
);


Subscriber.create({
 name: "Jon",
 email: "jon@jonwexler.com",
 zipCode: "890876"
})
 .then(subscriber => console.log(subscriber))
 .catch(error => console.log(error.message));
var subscriber;
Subscriber.findOne({
 name: "Jon"
}).then(result => {
 subscriber = result;
 console.log(subscriber.getInfo());
});file:/D:/User/Anton/Documents/WTAT1/ChoreSplit/