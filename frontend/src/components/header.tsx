import { AppBar, Button, Container, Stack, Toolbar, Typography } from "@mui/material";

function Header() {
  return (
    <AppBar sx={{display: "flex", justifyContent: "space-between"}} color="primary">
        <Container maxWidth={"xl"}>
            <Toolbar sx={{display:'flex', justifyContent: 'space-between'}}>
                <Stack alignItems={"center"}>
                    <Typography variant="body1">Market</Typography>
                    <Typography variant="body2">Place</Typography>
                </Stack>
                <Button variant="contained" >Добавление товара</Button>
            </Toolbar>
        </Container>
    </AppBar>
  )
}

export default Header