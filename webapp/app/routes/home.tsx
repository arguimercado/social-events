import { Typography,List, ListItem, ListItemText } from "@mui/material";
import type {Route} from "./+types/home"

export async function clientLoader() {
  
  const response = await fetch('http://localhost:5034/api/activities', {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
    },
  });

  var data = await response.json();

  return data as Activity[];
}

const Home = ({loaderData} : Route.ComponentProps) => {
  const activities = loaderData;
  return (
    <>
      <Typography variant="h4" >Home</Typography>
      <List>
        {activities.map(activity => (
          <ListItem key={activity.id}>
            <ListItemText>
              {activity.title}
            </ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  )
}

export default Home