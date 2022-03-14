import React from 'react';

import {ComponentMeta, ComponentStory} from '@storybook/react';
import PaymentPage from "./PaymentPage";

export default {
    title: 'Pages/PaymentPage',
    component: PaymentPage,
    argTypes: {},
} as ComponentMeta<typeof PaymentPage>;

const Template: ComponentStory<typeof PaymentPage> = () => {
    return <PaymentPage />;
};

export const Default = Template.bind({});