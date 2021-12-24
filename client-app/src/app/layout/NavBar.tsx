import React from "react";
import { Container, Menu } from "semantic-ui-react";
interface Props {
  openForm: () => void;
}

export default function NavBar({ openForm }: Props) {
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header>
          <img
            src="/assets/logo.png"
            alt="logo"
            style={{ marginRight: "10em" }}
          />
          Reactivities
        </Menu.Item>
        <Menu.Item name="Activities" />
        <Menu.Item>
          {/* <Button positive content="Create Activity" /> */}
          {/* the button cause Error at the Browser */}
          <button onClick={openForm}>Create Activity</button>
        </Menu.Item>
      </Container>
    </Menu>
  );
}
