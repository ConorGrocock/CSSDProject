import React from 'react';

import {ComponentMeta, ComponentStory} from '@storybook/react';
import InvoicePage from "./InvoicePage";

export default {
    title: 'Components/InvoicePage',
    component: InvoicePage,
    argTypes: {},
} as ComponentMeta<typeof InvoicePage>;

const Template: ComponentStory<typeof InvoicePage> = ({...args}) => {
    return <InvoicePage {...args} />;
};

export const Default = Template.bind({});