const { MongoClient } = require('mongodb');

const uri = "mongodb+srv://devvsakib:S9GOFECAPROgVxYM@cluster0.oqnwndl.mongodb.net/?retryWrites=true&w=majority";

async function main() {
    const client = new MongoClient(uri, { useNewUrlParser: true, useUnifiedTopology: true });

    try {
        // Connect to the MongoDB cluster
        await client.connect();

        // Specify the database and collection
        const database = client.db('test'); // replace 'your_database_name' with the actual database name
        const collection = database.collection('users');

        // Query the collection
        const users = await collection.find().toArray();

        // Print the results
        console.log(users);
    } catch (e) {
        console.error(e);
    } finally {
        // Close the connection
        await client.close();
    }
}

main().catch(console.error);
