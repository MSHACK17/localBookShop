import { ApolloClient, createNetworkInterface } from 'apollo-client';
import {GRAPHQL_ENDPOINT} from "../Constants/Constants";

const clientConfig = new ApolloClient({
  networkInterface: createNetworkInterface({
    uri: GRAPHQL_ENDPOINT
  })
});

export function graphqlClient(): ApolloClient {
  return clientConfig;
}
