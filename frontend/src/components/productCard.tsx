import { Box, Card, Divider, Rating, Stack, Typography } from "@mui/material"
import { Product } from "../domain/product"

interface IProps {
    product: Product
}

function ProductCard(props: IProps) {
    const {product} = props

    return (
        <Card sx={{p: 1, border: "1px solid lightgray", borderRadius: 2, maxWidth: 200}}>
            <Stack>
                <Box bgcolor={"GrayText"} width={"200px"} height={"200px"}/>
                <Rating defaultValue={product.rating} readOnly/>
                <Typography variant="body1">{product.name}</Typography>
            </Stack>
        </Card>
    )
}

export default ProductCard