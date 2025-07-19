import axios from "axios";
import type { Route } from "./+types/dashboard.ts";
import { List, ListItem, ListItemText } from "@mui/material";

export async function clientLoader() {

  const response = await axios.get<Activity[]>(
      "http://localhost:5034/api/activities",
      {
         method: "GET",
         headers: {
            "Content-Type": "application/json",
         },
      }
  );

   return response;
}

const Dashboard = ({ loaderData }: Route.ComponentProps) => {
   const { data } = loaderData;

   return (
      <>
         <List>
            {data.map((activity) => (
               <ListItem key={activity.id}>
                  <ListItemText>{activity.title}</ListItemText>
               </ListItem>
            ))}
         </List>
      </>
   );
};

export default Dashboard;
